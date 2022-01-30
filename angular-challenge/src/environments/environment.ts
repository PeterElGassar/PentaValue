// This file can be replaced during build by using the `fileReplacements` array.
// `ng build --prod` replaces `environment.ts` with `environment.prod.ts`.
// The list of file replacements can be found in `angular.json`.

export const environment = {
  production: false,
  baseUrl:"https://localhost:44384/api/",

  firebase:{
    apiKey: "AIzaSyC20giYRdIiqDMspG9vNIX7oKYIIg0KkbU",
    authDomain: "mobile-auth-task.firebaseapp.com",
    projectId: "mobile-auth-task",
    storageBucket: "mobile-auth-task.appspot.com",
    messagingSenderId: "354350160620",
    appId: "1:354350160620:web:8e69ec9e3324b02ffae3c9"
  }
};

/*
 * For easier debugging in development mode, you can import the following file
 * to ignore zone related error stack frames such as `zone.run`, `zoneDelegate.invokeTask`.
 *
 * This import should be commented out in production mode because it will have a negative impact
 * on performance if an error is thrown.
 */
// import 'zone.js/dist/zone-error';  // Included with Angular CLI.
