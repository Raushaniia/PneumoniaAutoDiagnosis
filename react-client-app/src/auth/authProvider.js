import { MsalAuthProvider, LoginType } from 'react-aad-msal';

const config = {
  auth: {
    authority: 'https://login.microsoftonline.com/f0510c5e-9b40-49d1-bd83-b454cd4e4f43',
    clientId: '033b9b7d-247d-423b-9f5e-053b4b2e07b1',
    redirectUri: 'http://localhost:3000/'
  },
  cache: {
    cacheLocation: "localStorage",
    storeAuthStateInCookie: true
  }
};

// Authentication Parameters
const authenticationParameters = {
  scopes: [
    'User.Read',
    'api://033b9b7d-247d-423b-9f5e-053b4b2e07b1/Pad4.Read',
    'api://033b9b7d-247d-423b-9f5e-053b4b2e07b1/Pad4.Write'
  ]
}

const options = {
  loginType: LoginType.Popup,
  tokenRefreshUri: window.location.origin + '/auth.html'
}

export const authProvider = new MsalAuthProvider(config, authenticationParameters, options)
