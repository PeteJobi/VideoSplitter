# Video Splitter
This repo provides a Windows desktop application for splitting or cutting up videos. Only supports Windows 10 and 11 (not tested on other versions of Windows). Powered by FFMPEG.

<img width="1791" height="1023" alt="Screenshot 2025-07-28 104435" src="https://github.com/user-attachments/assets/50673a4b-dd0a-4551-ac4a-bc13a9d59c06" />

## How to build
You need to have at least .NET 9 runtime installed to build the software. Download the latest runtime [here](https://dotnet.microsoft.com/en-us/download). If you're not sure which one to download, try [.NET 9.0 Version 9.0.203](https://dotnet.microsoft.com/en-us/download/dotnet/thank-you/sdk-9.0.203-windows-x64-installer)

In the project folder, run the below
```
dotnet publish -c Release -p:Platform=x64 -p:WindowsAppSDKSelfContained=true -p:WindowsPackageType=None
```
When that completes, go to `\bin\Release\net<version>-windows\win-x64` and you'll find the **VideoSplitter.exe**.

## Run without building
You can also just download the release builds if you don't wish to build manually. Unfortunately packages created in WinUI 3 have to be signed with a certificate, and certificates sourced from trusted companies cost hundreds of dollars. If you wish to install the package, you'll have to install a certificate signed by myself, as described [here](https://github.com/PeteJobi/VideoSplitter/releases/tag/cert). You only need to do this once - future updates will not require different certificates.

## How to use
When you open the program, you will be prompted to upload a video. Once that is done, you will be taken to the splitter interface page. At the bottom, you have a video timeline with which you can manipulate added range sections. You can drag the playhead to seek the video and click anywhere in the timeline to change the current position of the video and the playhead. 
Place the playhead at the position you wish to split the video and click the split button (scissors icon) to create new sections. Click on a section to select its range. Right clicking a section will bring up a context menu with which you can delete or play the section. Drag sections to change their positions in the video or resize them to increase or decrease their durations.

Above the timeline, you have the video's current position, which you can manually adjust for precise control of the playhead's position. After that is the video's total duration and two buttons you can use to step between frames. To the right of that, you have two buttons to step between sections and a button to split at the playhead's position. At the extreme right, you have a slider and buttons you can use to scale in or scale out of the timeline. The higher the scale, the easier you can control the playhead's position, and the less you can see of the video's timeline.

Just above those, we have simpler video controls. A button to play or pause the video, a button to play the currently selected section, and a slider to control the video's current position.

On the right are some action buttons. 
- Use the **Add range** feature if you wish to create a precise range. Press the button and enter the Start and End times of the range.
- Use the **Intervals** feature if you want to split the entire video into equal chunks. Press the button and enter the duration of each chunk. The last range may have a duration lower than this value. Note that using this feature will clear any ranges that were created previously.
- Click the **Select all** button to select or deselect all the ranges.
- Use the **Join** feature to join multiple ranges into one. Enable multiselect mode, select the ranges you wish to merge and click the button.
- Click the **Delete** button to delete selected ranges.

Under the action buttons, you have the **Multiselect** checkbox which switches between single and multiselect mode, and the list of ranges created. For any range, you can manually modify the **Start** or **End** times for precise control. You can also delete a range with the **Delete** button or play the section with the **Play Section** button.

When you're done creating and refining ranges, click the "**Split!**" button to start the split process. A progress bar showing the progress of the split operation, as well as some texts showing the current file and how many has been processed will show up. While the process is on-going, you can choose to pause or cancel it. Once the process is done, you can click the "**View**" button to view the output.

The output files will be located in a folder created in the same folder as the input file. This folder will have the same file name as the input file with "__SplitVideos_" appended to it. Be warned that if such a folder exists, it will be deleted.

Click the **Go back** button to return to the file selection page.
