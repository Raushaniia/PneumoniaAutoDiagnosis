import { MsalAuthProvider, LoginType } from 'react-aad-msal';

const config = {
  auth: {
    authority: 'https://login.microsoftonline.com/e9e18706-7eba-446b-a3df-e1bde79cf7c0',
    clientId: 'bdedf839-fb9e-4276-8f4d-6608468c1fa6',
    //redirectUri: 'http://localhost:3000/patients'
  },
  cache: {
    cacheLocation: "localStorage",
    storeAuthStateInCookie: true
  }
};

// Authentication Parameters
const authenticationParameters = {
  scopes: [
    'openid',
    'offline_access' ,
    'https://domainpad.onmicrosoft.com/bdedf839-fb9e-4276-8f4d-6608468c1fa6/Pad.read'
  ]
}

const options = {
  loginType: LoginType.Popup,
  //tokenRefreshUri: window.location.origin + '/auth.html'
}

export const authProvider = new MsalAuthProvider(config, authenticationParameters, options)
