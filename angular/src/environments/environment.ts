import { Environment } from '@abp/ng.core';

const baseUrl = 'http://localhost:4200';

export const environment = {
  production: false,
  application: {
    baseUrl,
    name: 'FormBook',
    logoUrl: '',
  },
  oAuthConfig: {
    issuer: 'https://localhost:44320/',
    redirectUri: baseUrl,
    clientId: 'FormBook_App',
    responseType: 'code',
    scope: 'offline_access FormBook',
    requireHttps: true,
  },
  apis: {
    default: {
      url: 'https://localhost:44320',
      rootNamespace: 'FormBook',
    },
  },
} as Environment;
