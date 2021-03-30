AudioToggle is a plugin that allows you to mute/unmute audio devices using your tablet buttons
Currently it supports [Windows](https://github.com/adryzz/AdryzzOTDTools/wiki/AudioToggle-configuration#windows) and [Linux](https://github.com/adryzz/AdryzzOTDTools/wiki/AudioToggle-configuration#linux).
## Windows
After installing the plugin you can either:
* Only mute the default device

Go into `Bindings` and set a button binding as follows.

![](https://github.com/adryzz/AdryzzOTDTools/blob/master/Wiki/AudioToggle/img0.png?raw=true)

* Mute any device.
First of all, we need to know the list of devices connected.

Go into `Bindings` and set a button binding as follows.

![](https://github.com/adryzz/AdryzzOTDTools/blob/master/Wiki/AudioToggle/img1.png?raw=true)

Press the button. You should see the list of devices in the `Console` tab.

![](https://github.com/adryzz/AdryzzOTDTools/blob/master/Wiki/AudioToggle/img2.png?raw=true)

Find the device you want, and keep in mind its device index (the device number)

Go on the `Tools` tab and change the device indices from `-1` to what you chose.

Now you can remove the `List audio devices` binding we set earlier

## Linux
Linux currently only supports toggling the `Master` and `Capture` mixers through alsamixer and it's really buggy.