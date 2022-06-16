# CPR Now

*** Revisiting this project because I'm not satisfied with how the app looks and mainly the code behind it. I will be using Angular(2+), Capacitor, and Ionic for learning experience.

Hands-only (chest compression-only) CPR assistant for mobile. Assisting user with audio and visual cues in 2 button presses (3 taps: App open, 'Start CPR Now' from checklist, 'Start' timer). Available for USA/Canada.

**Features:**

- From app open to start in 3 taps
- Visual and audio cues
- Completely offline
- CPR check list
- Compression depth reminder
- 100-120 CPM setting
- Last 10 start-end time
- Auto sets phone volume so audio cue is heard while giving CPR
- Auto sets phone's volume back to user's volume setting when app is closed or paused

<a href='https://play.google.com/store/apps/details?id=com.eddevs.cprnow&pcampaignid=pcampaignidMKT-Other-global-all-co-prtnr-py-PartBadge-Mar2515-1'><img alt='Get it on Google Play' src='https://play.google.com/intl/en_us/badges/static/images/badges/en_badge_web_generic.png' width="250px" /></a>

Google Play and the Google Play logo are trademarks of Google LLC.

## Screenshots/Gif

<p float="left">
  <img src="https://media.giphy.com/media/4jlB2BXw4u7rZkn2vk/giphy.gif" alt="GIF of CPR Now" />
  <br/>
  <img src="/images/1 check list.png" alt="CPR check list" width="200px" />
  <img src="/images/2 ui.png" alt="Main page: CPR cpm/bpm timer" width="200px" />
  <img src="/images/3 cues.png" alt="CPR timer started and screenshotted on beat" width="200px" />
</p>

## Frameworks/Libraries used

- .NET
- Xamarin.Essentials
- Xamarin.Forms
- Xamarin.FFImageLoading.Svg.Forms
- Newtonsoft.Json
- Forms9Patch (Auto font size labels)

## To Do

- :heavy_check_mark: Publish on Google Play Store
- :black_square_button: Publish on iOS App Store

## User requirements

Status | UR # | Description
--- | --- | ---
:heavy_check_mark: | 1 | App works offline. No cell/internet service usage after installation.
:heavy_check_mark: | 2 | Language in English
:heavy_check_mark: | 3 | Follow color-related visual impairment guidelines by WCAG, 4.5:1 contrast ratio
:heavy_check_mark: | 4 | 14pt font or greater
:heavy_check_mark: | 5 | No quick flashing, seizure inducing, elements. 100 - 120 CPM = 1.67 - 2 Hz which is under 3 Hz and is uncommon to trigger seizure.
:heavy_check_mark: | 6 | A small, compared to screen, flashing/pulsating indicator for BPM. Indicator can not be more than 25% of screen area at typical viewing distances (Mozilla web accessibility).
:heavy_check_mark: | 7 | Image showing placement of hands on chest
:heavy_check_mark: | 8a | Audio cue for every compression
:heavy_check_mark: | 8b | Visual cue for every compression
:heavy_check_mark: | 9a | Ability to start CPM
:heavy_check_mark: | 9b | Ability to stop CPM
:heavy_check_mark: | 10 | Ability to set BPM between 100-120
:heavy_check_mark: | 11 | Default 100BPM
:heavy_check_mark: | 12 | CPR check list for user
:heavy_check_mark: | 13 | Start CPR button below check list
:heavy_check_mark: | 14 | Timestamp since BPM started for an estimate on when chest compression-only CPR started
:heavy_check_mark: | 15 | Include liability/disclaimer
:heavy_check_mark: | 16 | Auto set volume for audio cue
:heavy_check_mark: | 17 | User can change the 'auto set volume' in settings. Default 80% of device's max.
:heavy_check_mark: | 18 | No advertisements
:heavy_check_mark: | 19 | Free app
:heavy_check_mark: | 20 | Available on Android
:black_square_button: | 21 | Available on iOS
:heavy_check_mark: | 22 | Display reminder of how deep, i.e. 2in./5cm deep or about 2 quarters wide

## Testing

Pass/Fail | # | Description
--- | --- | ---
:heavy_check_mark: | 1 | Saves CPM change (100, 105, 110, 115, 120)
:heavy_check_mark: | 2 | Display correct CPM on main page and settings page
:heavy_check_mark: | 3 | Visual and audio cue is ± 3cpm for 1 min using a tap tempo tool
:heavy_check_mark: | 4 | Visual and audio cue is continuously on for 10 min for 100 CPM
:heavy_check_mark: | 5 | CPM metronome starts when start button is pressed
:heavy_check_mark: | 6 | CPM metronome stops when swiped to different page and start-end time is updated
:heavy_check_mark: | 7 | CPM metronome stops when stop button is pressed and start-end time is updated
:heavy_check_mark: | 8 | CPM metronome stops when app is paused and start-end time is updated
:heavy_check_mark: | 9 | CPM metronome stops when app is closed and start-end time is updated
:heavy_check_mark: | 10 | Save start-end time
:heavy_check_mark: | 11 | Display correct start time on main page (same time displayed on phone)
:heavy_check_mark: | 12 | Display the last start-end time as the first entry in history
:heavy_check_mark: | 13 | Display up to 10 most recent start-end time in history in reverse chronological order
:heavy_check_mark: | 14 | Saves auto set volume
:heavy_check_mark: | 15 | Sets auto set volume when CPM metronome is on
:heavy_check_mark: | 16 | Sets volume back to user's original volume level on app pause (app in background but not terminated)
:heavy_check_mark: | 17 | Sets volume back to user's original volume level on app close (app termination)
:heavy_check_mark: | 18 | Start CPR Now button on check list brings user to main page
:heavy_check_mark: | 19 | App works in airplane mode
:heavy_check_mark: | 20 | Disclaimer is displayed in settings page
:heavy_check_mark: | 21 | Disclaimer is displayed on initial app startup requiring user input. If user is disagrees, app closes. If user agrees, disclaimer modal closes and does not appear.

## Prototype

Initial thoughts/requirements + sketches/wireframe in _/prototype/_.

<img src="/prototype/sketch.png" alt="Sketches of CPR Now screens during designing process" width="500px" />
