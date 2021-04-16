# Weather App Using MVVM Architecture

## _Overview_

![alt text](Assets/weatherApp1.png "Title")
![alt text](Assets/weatherApp2.png "Title")

The Weather App shows real time weather data for any city in the world. It uses the AccuWeather API for searching and retrieving weather data.

This tool uses Model-View-ViewModel (MVVM) architecture and was written in C#/.NET with the Microsoft Windows Presentation Foundation (WPF) UI framework.

### Features
- Current Date
- Temperature in Fahrenheit
- Cloud Conditions
- Rain Conditions

### Setup
1. Go to the site https://developer.accuweather.com/ and create a free developer account.
2. Once you have created an account, go to the `MY APPS` tab and click on the `Add a new App` button to create a new app.
3. Once you have a new app in AccuWeather, copy the `API Key` generated by the AccuWeather site.
4. Navigate to the file `ViewModel/Helpers/WeatherHelper.cs`. Once in that file, paste your `API Key` into the string on line 23. 
   - This line is blocked by comments and should be obvious of where to place the key.
5. Assuming there are no problems with your API key, you should be able to build and run the application.


### How It Works

Enter the name of your desired city in the textbox at the top. After pressing the `ENTER` key or the `Search` button, a list will populate below. Click on a selection and the weather data will show in the blue area below.



#### Development

This tool was written in C#/.NET and was creating using the Microsoft Windows Presentation Foundation UI framework. Free use for everyone. MIT License.