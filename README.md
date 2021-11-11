# Whoop4.0BatteryReset
Simple app to reset the whoop 4.0 battery when it craps out.

## Original post from reddit 
*https://www.reddit.com/r/whoop/comments/qr7ubk/aaaand_i_fixed_my_40_battery_pack_howto_inside/*

So just moments ago I posted this thread: https://www.reddit.com/r/whoop/comments/qr6i1f/another_dead_40_battery_pack/

I mentioned in there that the battery was showing up as a USB serial port when plugging it into my computer. Since I'm a software engineer, and because whoop customer service is ignoring me, I thought "hey, why not see if I can troubleshoot this thing on my own".

So, I wrote a quick little C# app to see if I could send/receive some data to/from the battery... I could successfully connect to the battery, open the port, and read data. When I sent some data to the battery, lo-and-behold, it reset itself and started working again.

I'd be interested to see if anyone else out there can do the same thing. While this might not be an ideal solution, my whoop is now charging, and will continue to be useful until they release a real patch for this issue.

## Link to the compiled binaries (Windows x64 executable)
https://anonfiles.com/Tf66kdUbua/COMSpike_zip

*Note: The exe zip is so large because I included the entire .NET 5 framework in the application, so that you won't have to install anything on your machine.*

How to run:

1. Unzip the file into a folder of your choice
2. Navigate to the "application" directory
3. Run the COMSpike.exe application
4. Follow the instructions in the app

This should work for most versions of Windows.

Please post/comment with your results, if you can!
