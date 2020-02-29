using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Web;
using System.Web.Security;
using Sitecore.Data;
using Sitecore.Data.Items;
using Sitecore.Diagnostics;
using Sitecore.ExperienceForms.Models;
using Sitecore.ExperienceForms.Processing;
using Sitecore.ExperienceForms.Processing.Actions;
using Sitecore.SecurityModel;

namespace Hackathon.Feature.RegisterTeam.Models
{
    public class RegisterTeam : SubmitActionBase<string>
    {
        private HttpClient client;
        HttpResponseMessage response;
        private static string fileName;
        /// <summary>
        /// Initializes a new instance of the <see cref="LogSubmit"/> class.
        /// </summary>
        /// <param name="submitActionData">The submit action data.</param>
        public RegisterTeam(ISubmitActionData submitActionData) : base(submitActionData)
        {
        }

        /// <summary>
        /// Tries to convert the specified <paramref name="value" /> to an instance of the specified target type.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="target">The target object.</param>
        /// <returns>
        /// true if <paramref name="value" /> was converted successfully; otherwise, false.
        /// </returns>
        protected override bool TryParse(string value, out string target)
        {
            target = string.Empty;
            return true;
        }

        /// <summary>
        /// Executes the action with the specified <paramref name="data" />.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <param name="formSubmitContext">The form submit context.</param>
        /// <returns>
        ///   <c>true</c> if the action is executed correctly; otherwise <c>false</c>
        /// </returns>
        protected override bool Execute(string data, FormSubmitContext formSubmitContext)
        {
            Assert.ArgumentNotNull(formSubmitContext, nameof(formSubmitContext));
            Dictionary<string, object> values = new Dictionary<string, object>();
            foreach (IViewModel fields in formSubmitContext.Fields)
            {
                try
                {
                    KeyValuePair<string, object> fieldData = GetFieldData(fields);
                    values.Add(fieldData.Key, fieldData.Value);
                }
                catch (Exception ex)
                {
                    Sitecore.Diagnostics.Log.Error(ex.Message, ex, typeof(RegisterTeam));
                }

            }

            //Disable the Security
            using (new SecurityDisabler())
            {
                Database master = Sitecore.Configuration.Factory.GetDatabase("master");
                if (master != null)
                {
                    //Here you need the Parent Item (new item will be child of this item)
                    Sitecore.Data.Items.Item parentItem = master.GetItem(new ID("{F9B025E2-42E6-489A-98A8-F660834062E2}"));
                    
                    //Get the template for the new item
                    TemplateItem teamTemplate = master.GetTemplate(Templates.Team.Id);

                    if (teamTemplate != null)
                    {
                        //Now, use Parent item to add a new item underneath and pass the item name and template as parameter
                        Item newItem = parentItem?.Add("NewItem", teamTemplate);

                        try
                        {
                            if (newItem != null)
                            {
                                newItem.Editing.BeginEdit();
                                newItem.Editing.EndEdit();
                            }
                        }
                        catch
                        {
                            newItem.Editing.CancelEdit();
                        }

                    }
                }
            }

            return true;
        }

        public string GetStatus(string data)
        {
            var datan = data;
            return datan;
        }
        public static KeyValuePair<string, object> GetFieldData(IViewModel postedField)
        {
            Assert.ArgumentNotNull((object)postedField, "postedField");
            IValueField valueField = postedField as IValueField;

            if ((valueField != null ? (valueField.AllowSave ? 1 : 0) : 0) == 0)
                return GenerateKeyValuePair(postedField.Name);

            var fileProperty = postedField.GetType().GetProperty("File");

            var file = fileProperty?.GetValue(postedField);

            if (fileProperty == null)
            {
                PropertyInfo property2 = postedField.GetType().GetProperty("Value");
                object postedValue2;
                postedValue2 = property2.GetValue((object)postedField);

                return GenerateKeyValuePair(postedField.Name, postedValue2);
            }
            else
            {
                if (file != null)
                {
                    var property = ((HttpPostedFileWrapper)fileProperty.GetValue(postedField)).InputStream;
                    fileName = ((HttpPostedFileWrapper)fileProperty.GetValue(postedField)).FileName;
                    var propertylenght = ((HttpPostedFileWrapper)fileProperty.GetValue(postedField)).ContentLength;
                    byte[] fileData = null;
                    using (var binaryReader = new BinaryReader(property))
                    {
                        fileData = binaryReader.ReadBytes(propertylenght);
                    }
                    object postedValue;
                    postedValue = fileData;
                    return GenerateKeyValuePair(postedField.ItemId, postedValue);
                }
                else
                {
                    return GenerateKeyValuePair(postedField.ItemId, null);
                }
            }
        }

        public static Dictionary<string, T> GetFieldsDictionary<T>(IList<IViewModel> fields)
        {
            Dictionary<string, T> values = new Dictionary<string, T>();
            foreach (IViewModel field in fields)
            {
                KeyValuePair<string, object> fieldData = GetFieldData(field);
                values.Add(fieldData.Key, (T)fieldData.Value);
            }
            return values;

        }

        private string GenerateJSONWebToken(Dictionary<string, object> userInfo, string password)
        {
            // Define const Key this should be private secret key  stored in some safe place
            Guid key = Guid.NewGuid();
            string keySend = "";

            keySend = "key=" + key.ToString();
            Sitecore.Security.SitecoreMembershipProvider provider = new Sitecore.Security.SitecoreMembershipProvider();
            MembershipCreateStatus status = MembershipCreateStatus.Success;
            Membership.CreateUser(@"portal\" + userInfo["Nif"], password, userInfo["Email"].ToString(), userInfo["Pergunta"].ToString(), userInfo["Resposta"].ToString(), false, out status);
            if (status != MembershipCreateStatus.Success)
                throw new MembershipCreateUserException(status);

            return keySend;
        }
        public static void UpdateUserKeyActivation(string userName, Guid key)
        {
            Sitecore.Security.Accounts.User user = Sitecore.Security.Accounts.User.FromName(userName, true);
            user.Profile.SetCustomProperty("KeyActivation", key.ToString());
            user.Profile.Save();
        }


        public static KeyValuePair<string, object> GenerateKeyValuePair(string key, object value = null)
        {
            return new KeyValuePair<string, object>(key, value);
        }
    }
}