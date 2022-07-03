package me.lukasong;

import com.formdev.flatlaf.FlatDarculaLaf;

import javax.swing.*;
import java.io.IOException;
import java.text.SimpleDateFormat;
import java.util.Date;

public class Main {

    public static GUI guiThisWindow;

    public static void main(String[] args){

        // create window
        //Platelet.doExtract("G:\\downloads\\YouTube-Playlist.xls");
        doAppendConsole("Starting main thread..");
        FlatDarculaLaf.install();
        guiThisWindow = new GUI();
        guiThisWindow.setVisible(true);

    }

    public static void doAppendConsole(String inputToAppend) {
        // get current time
        String timeStampThis = new SimpleDateFormat("HH.mm.ss").format(new Date());
        // get current console
        Local.strCurrentOutput = "\n" + "[" + timeStampThis + "] " + inputToAppend;
        GUI.txtConsoleArea.append(Local.strCurrentOutput);
        JScrollBar sbConsoleArea = GUI.spConsoleArea.getVerticalScrollBar();
        sbConsoleArea.setValue(sbConsoleArea.getMaximum());
        // update
        try {
            guiThisWindow.invalidate();
            guiThisWindow.validate();
            guiThisWindow.repaint();
        } catch(Exception e) {
            e.toString(); // useless
        }
    }

}
