package me.lukasong;

import javax.swing.*;
import javax.swing.border.Border;
import java.awt.*;
import java.awt.event.*;
import java.io.IOException;
import java.net.URI;
import java.net.URISyntaxException;
import java.util.ArrayList;

import static me.lukasong.Main.doAppendConsole;

public class GUI extends JFrame {

    private JButton btnPlaylist = new JButton(Local.strButtonLoad);
    private JButton btnThis = new JButton(Local.strButtonThis);
    private JButton btnNext = new JButton(Local.strButtonNext);
    private JButton btnPrevious = new JButton(Local.strButtonPrevious);
    private JButton btnShuffle = new JButton(Local.strButtonShuffle);
    private JButton btnRandom = new JButton(Local.strButtonRandom);
    private JButton btnGoto = new JButton(Local.strButtonGoTo);
    private JButton btnDownload = new JButton(Local.strButtonDownload);
    private JButton btnInstructions = new JButton(Local.strButtonInstructions);
    private JTextField txtURL = new JTextField();
    public static JTextField txtConsole = new JTextField();
    public static JTextField txtGoto = new JTextField();

    public static JTextArea txtConsoleArea = new JTextArea();
    public static JScrollPane spConsoleArea = new JScrollPane(txtConsoleArea);

    private JRadioButton toggleCycle = new JRadioButton();

    private JLabel lblThisPlaylist = new JLabel(Local.strThisPlaylist + ": ");
    private JLabel lblThisSong = new JLabel(Local.strThisSong + ": ");
    private JLabel lblNextSong = new JLabel(Local.strNextSong + ": ");
    private JLabel lblPreviousSong = new JLabel(Local.strPreviousSong + ": ");
    public static JLabel lblCurrentPlaylist = new JLabel(Local.strCurrentPlaylist);
    public static JLabel lblCurrentSong = new JLabel(Local.strCurrentSong);
    public static JLabel lblCurrentNextSong = new JLabel(Local.strCurrentNextSong);
    public static JLabel lblCurrentPreviousSong = new JLabel(Local.strCurrentPreviousSong);
    private JLabel lblCycle = new JLabel(Local.strToggleTimer + "? ");
    public static JLabel lblCurrentIndex = new JLabel(Local.strCurrentPosition + ": " + Integer.toString(Local.intCurrentIndex) + " / " + Integer.toString((Local.intCurrentSize)));
    private JLabel lblTime = new JLabel(Local.strTimer + ": " + Local.dblCurrentTimeIndex + " / " + Local.dblCurrentTime);
    private JLabel lblConsole = new JLabel(Local.strConsole + ":");
    public static JLabel lblMe = new JLabel(Local.strMe);

    private JLabel imgRiamu = new JLabel(new ImageIcon(this.getClass().getResource("/TripSitter.png")));

    public GUI(){
        doAppendConsole("Building the GUI...");
        // calculating center
        Dimension dimension = Toolkit.getDefaultToolkit().getScreenSize();
        int intCenterX = (int) ((dimension.getWidth() - 800) / 2);
        int intCenterY = (int) ((dimension.getHeight() - 400) / 2);
        // building window
        setTitle(Local.strWindowName);
        setSize(800,400);
        setLocation(new Point(intCenterX,intCenterY));
        setLayout(null);
        setResizable(false);
        initComponent();
        initEvent();
        // configuring individual elements
        txtGoto.setForeground(Color.decode("#BBBBBB"));
        txtGoto.setBackground(Color.decode("#45494A"));
        txtConsole.setEditable(false);
        txtConsoleArea.setEditable(false);
        txtConsoleArea.setForeground(Color.decode("#BBBBBB"));
        txtConsoleArea.setBackground(Color.decode("#45494A"));
        lblCurrentPlaylist.setForeground(Color.decode("#BBBBBB"));
        lblCurrentSong.setForeground(Color.decode("#BBBBBB"));
        lblCurrentIndex.setForeground(Color.decode("#BBBBBB"));
        lblCurrentNextSong.setForeground(Color.decode("#BBBBBB"));
        lblCurrentPreviousSong.setForeground(Color.decode("#BBBBBB"));
        Border border = BorderFactory.createLineBorder(Color.decode("#646464"));
        txtConsoleArea.setBorder(BorderFactory.createCompoundBorder(border,
                BorderFactory.createEmptyBorder(10, 10, 10, 10)));
        new FancyMe().start();
        doAppendConsole("GUI complete! uwu");
    }

    private void initComponent(){

        imgRiamu.setBounds(5,-175, 300, 700);
        add(imgRiamu);

        txtURL.setBounds(325,50, 300,25);
        add(txtURL);

        btnPlaylist.setBounds(635,50, 125,25);
        add(btnPlaylist);

        lblThisPlaylist.setBounds(325,25, 150,25);
        add(lblThisPlaylist);

        lblCurrentPlaylist.setBounds(425,25, 300,25);
        add(lblCurrentPlaylist);

        lblThisSong.setBounds(325,80, 300,25);
        add(lblThisSong);

        lblCurrentSong.setBounds(425,80, 150,25);
        add(lblCurrentSong);

        btnThis.setBounds(635,80, 105,22);
        add(btnThis);

        lblNextSong.setBounds(325,105, 300,25);
        add(lblNextSong);

        lblCurrentNextSong.setBounds(425,105, 150,25);
        add(lblCurrentNextSong);

        btnNext.setBounds(635,105, 105,22);
        add(btnNext);

        lblPreviousSong.setBounds(325,130, 300,25);
        add(lblPreviousSong);

        lblCurrentPreviousSong.setBounds(425,130, 150,25);
        add(lblCurrentPreviousSong);

        btnPrevious.setBounds(635,130, 125,22);
        add(btnPrevious);

        lblCurrentIndex.setBounds(640,25, 300,25);
        add(lblCurrentIndex);

        lblCycle.setBounds(325,160, 300,25);
        //add(lblCycle);

        toggleCycle.setBounds(510,160, 300,25);
        //add(toggleCycle);

        lblTime.setBounds(638,160, 300,25);
        //add(lblTime);

        lblConsole.setBounds(325,200, 300,25);
        add(lblConsole);

        spConsoleArea.setBounds(325,225, 300,100);
        add(spConsoleArea);

        lblMe.setBounds(675,320, 300,25);
        add(lblMe);

        btnShuffle.setBounds(325,160, 100,25);
        add(btnShuffle);

        btnRandom.setBounds(425,160, 100,25);
        add(btnRandom);

        btnGoto.setBounds(525,160, 100,25);
        add(btnGoto);

        txtGoto.setBounds(630,160, 50,22);
        add(txtGoto);

        btnDownload.setBounds(635,223, 125,22);
        add(btnDownload);

        btnInstructions.setBounds(635,248, 125,22);
        add(btnInstructions);

    }

    private void initEvent(){

        btnPlaylist.addActionListener(new ActionListener() {
            public void actionPerformed(ActionEvent e) {
                btnPlaylist(e);
            }
        });

        btnNext.addActionListener(new ActionListener() {
            public void actionPerformed(ActionEvent e) {
                btnNext(e);
            }
        });

        btnPrevious.addActionListener(new ActionListener() {
            public void actionPerformed(ActionEvent e) {
                btnPrevious(e);
            }
        });

        btnThis.addActionListener(new ActionListener() {
            public void actionPerformed(ActionEvent e) {
                btnThis(e);
            }
        });

        btnShuffle.addActionListener(new ActionListener() {
            public void actionPerformed(ActionEvent e) {
                btnShuffle(e);
            }
        });

        btnRandom.addActionListener(new ActionListener() {
            public void actionPerformed(ActionEvent e) {
                btnRandom(e);
            }
        });

        btnGoto.addActionListener(new ActionListener() {
            public void actionPerformed(ActionEvent e) {
                btnGoto(e);
            }
        });

        btnDownload.addActionListener(new ActionListener() {
            public void actionPerformed(ActionEvent e) {
                btnDownload(e);
            }
        });

        btnInstructions.addActionListener(new ActionListener() {
            public void actionPerformed(ActionEvent e) {
                btnInstructions(e);
            }
        });

    }

    // load playlist
    private void btnPlaylist(ActionEvent evt) {
        Main.doAppendConsole("Loading playlist..");
        Platelet.doExtract(txtURL.getText());
        Main.doAppendConsole("Playlist loaded!");
    }

    // move forward
    private void btnNext(ActionEvent evt) {
        Main.doAppendConsole("Moving index up by one..");
        Platelet.doForward();
    }

    // move back
    private void btnPrevious(ActionEvent evt) {
        Main.doAppendConsole("Moving index back by one..");
        Platelet.doBack();
    }

    // copy this
    private void btnThis(ActionEvent evt) {
        Main.doAppendConsole("Copying current..");
        Platelet.doCopy();
    }

    // shuffle
    private void btnShuffle(ActionEvent evt) {
        Platelet.doShuffle();
    }

    // random
    private void btnRandom(ActionEvent evt) {
        Platelet.doRandom();
    }

    // go to
    private void btnGoto(ActionEvent evt) {
        try {
            Platelet.doGoto(Integer.parseInt(txtGoto.getText()));
        } catch (Exception e) {
            Main.doAppendConsole("Please enter a valid index within the bound of 0 < x < " + Local.intCurrentSize);
        }
    }

    // download
    private void btnDownload(ActionEvent evt) {
        Desktop desktop = java.awt.Desktop.getDesktop();
        try {
            //specify the protocol along with the URL
            URI oURL = new URI(
                    "http://www.williamsportwebdeveloper.com/FavBackUp.aspx");
            desktop.browse(oURL);
        } catch (URISyntaxException e) {
            e.printStackTrace();
        } catch (IOException e) {
            e.printStackTrace();
        }
    }

    // instructions
    private void btnInstructions(ActionEvent evt) {
        JOptionPane.showMessageDialog(this,
                "Hit the Get File button and then put your playlist there. Download the file it gives and then put the path to that file on your computer in the playlist loader. enjoy uwu!");
    }

}

class FancyMe extends Thread {
    public FancyMe() {
        super();
    }

    //Creating our arraylist
    ArrayList<String> arraylistTitles = new ArrayList<String>();

    //Creating our FPS
    int intSleep = 0;
    int intRotation = -1;

    //Animating!
    public void run() {
        buildRotatingTitle();
        boolean animateTitle = true;
        while(animateTitle == true) {
            intRotation += 1;
            if(intRotation > (arraylistTitles.size() - 1)) intRotation = 0;
            if(arraylistTitles.get(intRotation).toString().equals("POST:INTROEND")) buildRotatingTitle();
            GUI.lblMe.setText(arraylistTitles.get(intRotation).toString());
            try {
                Thread.sleep(intSleep);
            } catch (InterruptedException e) {
                e.printStackTrace();
            }
        }
    }

    //Our rotating titles for the program itself
    public void buildRotatingTitle(){
        intSleep = 100;
        intRotation = 0; //resetting our place along the animation
        arraylistTitles.clear();
        arraylistTitles.add("<html><span style='color:#FFB1B0'>l</span><span style='color:#FFDFBE'>u</span><span style='color:#FFFFBF'>k</span><span style='color:#B4F0A7'>a</span><span style='color:#BBBBBB'>#8375</span></html>");
        arraylistTitles.add("<html><span style='color:#CC99FF'>l</span><span style='color:#FFB1B0'>u</span><span style='color:#FFDFBE'>k</span><span style='color:#FFFFBF'>a</span><span style='color:#BBBBBB'>#8375</span></html>");
        arraylistTitles.add("<html><span style='color:#A9D1F7'>l</span><span style='color:#CC99FF'>u</span><span style='color:#FFB1B0'>k</span><span style='color:#FFDFBE'>a</span><span style='color:#BBBBBB'>#8375</span></html>");
        arraylistTitles.add("<html><span style='color:#B4F0A7'>l</span><span style='color:#A9D1F7'>u</span><span style='color:#CC99FF'>k</span><span style='color:#FFB1B0'>a</span><span style='color:#BBBBBB'>#8375</span></html>");
        arraylistTitles.add("<html><span style='color:#FFFFBF'>l</span><span style='color:#B4F0A7'>u</span><span style='color:#A9D1F7'>k</span><span style='color:#CC99FF'>a</span><span style='color:#BBBBBB'>#8375</span></html>");
        arraylistTitles.add("<html><span style='color:#FFDFBE'>l</span><span style='color:#FFFFBF'>u</span><span style='color:#B4F0A7'>k</span><span style='color:#A9D1F7'>a</span><span style='color:#BBBBBB'>#8375</span></html>");
        arraylistTitles.add("<html><span style='color:#FFB1B0'>l</span><span style='color:#FFDFBE'>u</span><span style='color:#FFFFBF'>k</span><span style='color:#B4F0A7'>a</span><span style='color:#BBBBBB'>#8375</span></html>");
    }

}
