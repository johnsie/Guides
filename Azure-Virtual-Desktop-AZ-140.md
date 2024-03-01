# Azure Virtual Deskop

### Capabilities

- Setup multi-session Windows 10 or 11 images

- Virtualising MS 365 apps, so they can be easily be distributed on whatever device the user is on

- Virtual desktops of older versions of Windows eg Windows 7, 10, 11

- Apply to RDS services

- Centralise and fine grain management 

- Provision personal desktops 


### Key Features

- Full desktop virtualisation without remote access gateways or other infrastructure needing to be set up

- Publish multiple host pools. Can have different chararctersiscs for different areas of the enterprise

- Bring your own image, or use one from a ggallery

- Sharing one image between multiple users

- Personal desktops

### Get Cracking With Azure Virtual Desktop

1. Create a free MS 365 Developer account and a free Azure account . Note that students may have other options for createing a free Azure account.

2. Log into Azure

3. In the search box at the top search for Azure Virttual Machine

4. Create a host pool


### But what should we consider when setting up host pools?

- Personal pools required? Desktop owned by user

- Density requirements? How many users will be allowed on one image?

- Performance needs of end users. 

- GPU. Do they need extra processing capability

- Region. Where are the users located

- Business functions. Can we group users by business function?

- Overall user count?

- Max session counts. How many people will really be using it at once

- Which applications are required by the individual users?


### Planning host pools


## Pool 1

- Light density

- Low performance

- No GPU

- North America - East

- 3,000 users

- 200 sessions



## Pool 2

- Medium density

- High performance

- GPU required

- North America - West

- 5,000 users

- 400 sessions



### Pool types

Personal 

- Image types available are not the multi-session versions



Pooled

-  Images types available are mult-ssession versions



### Where can we get the images from?

- Azure  Image Gallery

- Manual VM Deployment

- Azure Resource Manager Template Integration

- Provision host pools using Azure Marketplacce


### Azure AdConnect

- Used to sync an on-prem Active Directory to Azure Entra ID

### Profile containerisation

- Profile contained in a VHD

- Needs to be conneted to the Virtual Machine

- FSLOgix used to manage this insde the virtual desktop solution

- Best practice

















