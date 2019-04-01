# PriceComparisonApp

## Android App Setup Commands
### Prerequisites
- install NativeScript Command line tool, guide on how can be found here: https://docs.nativescript.org/start/quick-setup

### Build
```
tns build android
```
### Run on android pc emulator
```
tns run android
```
### E2E Test - Appium
```
npm run e2e --runType=android23
```

after this command is run the command line will output a path too the apps debug
apk that you can then install.

this app takes prices for products aswell as brand & type of product,
### API Changes
- Created Initial Entity Framework Code, untested needs to add DB to Azure & Instance.

- Uploaded the final API version. The API runs on Azure and is Connected to the Azure SQL DB.

### APP Changes
- Support For locales en, ru, ga & fr added, information on how this was done can
  be found seen here: https://github.com/rborn/nativescript-i18n.
- App Images e.g. logo, icon etc scaled for varying screen size support,
  tool used to easily create scaled logo & icon images can be found here: http://nsimage.brosteins.com.
- App UML Class diagram drawn up for app functionality.
- Core functionality implemented
- App build & all functionality tested manually and working in android emulator.
- E2E Tests implemented but not working.
