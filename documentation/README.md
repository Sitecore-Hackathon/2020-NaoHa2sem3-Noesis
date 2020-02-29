Documentation
Summary

Category: Sitecore Hackathon Website 

Replacement of the existing Sitecore Hackathon Website
The main goal was reproduce the most of important feature in the website and
Develop some new ideas.

Pre-requisites

Please make sure you have the following requirements:
    - Sitecore 9.3.0 rev. 003498 
    - Sitecore Experience Accelerator 9.3.0

Installation

For installation will be need to install the package of website:

1. Use the Sitecore Installation wizard to install the package (#link-to-package)

Configuration

It will be necessary to do configuration on SMTP Server in (C:\inetpub\wwwroot\naoha2sem3sc.dev.local\App_Config\Sitecore\EmailExperience) whith the code below:
 
 <smtpSettings type="Sitecore.EDS.Core.Net.Smtp.SmtpSettings, Sitecore.EDS.Core" singleInstance="true">
    <server>smtp.sendgrid.net</server>
    <port>587</port>
    <userName></userName>
    <password></password>
    <authenticationMethod>None</authenticationMethod>
    <startTls>false</startTls>
    <proxySettings ref="exm/eds/proxySettings" />
</smtpSettings>

Usage

In order to reproduce the actual hackathon website, we have use some SXA functionalities to facilitate the creation of any page and the render of the content with the components of SXA.
Also, we have developed a new idea of form to hackathon website to subscribe new hackathon teams, using sitecore forms 

Video

https://www.youtube.com/watch?v=HgMEvaSWuog

