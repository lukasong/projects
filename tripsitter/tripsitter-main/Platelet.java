package me.lukasong;

import java.io.BufferedReader;
import java.io.FileReader;
import java.io.IOException;
import java.awt.datatransfer.StringSelection;
import java.awt.Toolkit;
import java.awt.datatransfer.Clipboard;
import java.util.Collections;
import java.util.Random;

public class Platelet {

    // note to self: ony set up to read a specific format from that one website
    public static void doExtract(String inputRaw) {
        // clearing
        Local.listURLs.clear();
        Local.listNames.clear();
        // set up things to keep track
        boolean boolURLPassed = false;
        int intSinceURL = -1;
        // reading line by line
        try(BufferedReader br = new BufferedReader(new FileReader(inputRaw))) {
            for(String line; (line = br.readLine()) != null; ) {
                // first, is this line a url
                if (line.contains("height=\"19\" valign=\"top\">https://www.youtube.com/watch?v=")) {
                    boolURLPassed = true;
                    intSinceURL = 0;
                    String strThisURL = line.substring(line.indexOf("\"top\">") + 6, line.indexOf("</td>"));
                    Local.listURLs.add(strThisURL);
                }
                if (boolURLPassed) {
                    intSinceURL += 1;
                    if (intSinceURL == 3) {
                        String strThisName = line.substring(line.indexOf("\"top\">") + 6, line.indexOf("</td>"));
                        Local.listNames.add(strThisName);
                        intSinceURL = -1;
                        boolURLPassed = false;
                    }
                }
            }
        } catch (IOException e) {
            e.printStackTrace();
        }
        // setting playlist title
        Local.strCurrentPlaylist = inputRaw;
        GUI.lblCurrentPlaylist.setText(Local.strCurrentPlaylist);
        Local.intCurrentIndex = 1;
        Local.intCurrentSize = Local.listURLs.size() + 1;
        GUI.lblCurrentIndex.setText(Local.strCurrentPosition + ": " + Integer.toString(Local.intCurrentIndex) + " / " + Integer.toString((Local.intCurrentSize)));
        // outputting
        Main.doAppendConsole("Playlist titles: " + Local.listNames.toString().replace("[", "").replace("]", "").replace(", ", "\n|-> Added: "));
        Main.doAppendConsole("Playlist urls: " + Local.listURLs.toString().replace("[", "").replace("]", "").replace(", ", "\n|-> Added: "));
        doUpdate(0);
    }

    public static void doUpdate(int inputIndex) {
        Main.doAppendConsole("Updating the playlist position...");
        try {
            if (inputIndex - 1 < 0) {
                Local.strCurrentPreviousSong = "A the start of the playlist!";
            } else {
                Local.strCurrentPreviousSong = Local.listNames.get(inputIndex - 1).toString();
            }
            if (inputIndex + 1 > Local.listNames.size()) {
                Local.strCurrentNextSong = "Reached end of playlist!";
            } else {
                Local.strCurrentNextSong = Local.listNames.get(inputIndex + 1).toString();
            }
            Local.strCurrentSong = Local.listNames.get(inputIndex).toString();
        } catch (Exception e) {
            Main.doAppendConsole("Could not load current song data!");
        }
        // update
        try {
            GUI.lblCurrentIndex.setText(Local.strCurrentPosition + ": " + Integer.toString(Local.intCurrentIndex) + " / " + Integer.toString((Local.intCurrentSize)));
            GUI.lblCurrentSong.setText(Local.strCurrentSong);
            GUI.lblCurrentNextSong.setText(Local.strCurrentNextSong);
            GUI.lblCurrentPreviousSong.setText(Local.strCurrentPreviousSong);
            Main.guiThisWindow.invalidate();
            Main.guiThisWindow.validate();
            Main.guiThisWindow.repaint();
        } catch(Exception e) {
            e.toString(); // useless
        }
        Main.doAppendConsole("Playlist positions updated! uwu");
    }

    public static void doBack() {
        if (Local.intCurrentIndex > 0) {
            Local.intCurrentIndex -= 1;
            doUpdate(Local.intCurrentIndex);
        }
        doCopy();
    }

    public static void doForward() {
        if (Local.intCurrentIndex < Local.listURLs.size()) {
            Local.intCurrentIndex += 1;
            doUpdate(Local.intCurrentIndex);
        }
        doCopy();
    }

    public static void doCopy() {
        try {
            StringSelection ssClipboard = new StringSelection(Local.listURLs.get(Local.intCurrentIndex).toString());
            Clipboard cbThis = Toolkit.getDefaultToolkit().getSystemClipboard();
            cbThis.setContents(ssClipboard, null);
        } catch (Exception e) {
            Main.doAppendConsole("Error trying to copy! D: see: " + e.toString());
        }
    }

    public static void doGoto(int inputIndex) {
        inputIndex += 1;
        if (inputIndex < Local.listURLs.size() && inputIndex > 0) {
            Local.intCurrentIndex = inputIndex;
            doUpdate(Local.intCurrentIndex);
        }
        Main.doAppendConsole("Index set to " + inputIndex);
        doCopy();
    }

    public static void doRandom() {
        Main.doAppendConsole("Selecting a random index..");
        Random rand = new Random();
        doGoto(rand.nextInt(Local.listURLs.size()));
        Main.doAppendConsole("Randomly set index to: " + Local.intCurrentIndex);
        doCopy();
    }

    public static void doShuffle()
    {
        Main.doAppendConsole("Generating seed for random shuffle..");
        Random rand = new Random();
        Main.doAppendConsole("Shuffling lists with seed..");
        Collections.shuffle(Local.listURLs, rand);
        Collections.shuffle(Local.listNames, rand);
        Main.doAppendConsole("Shuffled!");
        doUpdate(Local.intCurrentIndex);
    }


}
