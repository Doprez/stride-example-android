# stride-example-android
A base project with configuration for Android.

# Set up
This project closely follows [This persons](https://github.com/stride3d/stride/discussions/1657) beautiful guide with one minor change.

## the change
It may be due to my environment but one of the issues I was facing was with the permissions so I kept the code but commented out the "close if permission isnt granted".
AndroidTestActivity.cs
![image](https://github.com/Doprez/stride-example-android/assets/73259914/d71b88d8-ccc5-4d21-a48e-4ff1d26d34cd)

## extra steps
I needed to add arm64 as a CPU option or else the project would build and pretend to run without actually using my connected device.
![image](https://github.com/Doprez/stride-example-android/assets/73259914/9bdadf7a-6ee4-48bb-a6bd-0a595b84719a)

You should also make sure you have the following tool installed: 
- goto `Tools -> Android -> Android SDK Manager`
and make sure the following are checked depending on your android version
![image](https://github.com/Doprez/stride-example-android/assets/73259914/85160c2f-4e95-42d7-a361-cd92daeed8c1)

and finally make sure the following tool is also checked
![image](https://github.com/Doprez/stride-example-android/assets/73259914/9cfc5a0d-e30d-4453-9f83-b59f44263f5e)

that should be it if you followed the rest of the initial set up from the guide above!

# Issues

- The background/skybox is black I dont know why
- you HAVE to make sure you clean and rebuild the porject before each run or else permissions will be denied
