package me.lukasong.maw;

import com.sun.corba.se.impl.orbutil.graph.Graph;

import javax.imageio.ImageIO;
import javax.swing.*;
import java.awt.*;
import java.awt.event.*;
import java.awt.geom.RoundRectangle2D;
import java.awt.image.BufferedImage;
import java.io.File;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;
import java.util.Map;

class Home extends JFrame {

    //Universal + Dashboard Variables
    public Color colorBackground = new Color(29, 26, 39);
    public Color colorAccent = new Color(45, 44, 62);
    public Color colorMenu = new Color(210, 210,  214);
    public Color colorMenuBokeh = new Color(122, 122, 125);
    public Color colorMenuAccent = new Color(113, 32, 234);

    public JLabel labelFauxTitle = new JLabel("");
    public JLabel labelFauxMenu = new JLabel("");

    public JLabel labelMenuDashboard = new JLabel("Dashboard");
    public JLabel labelMenuInstall = new JLabel("Install");
    public JLabel labelMenuManage = new JLabel("Manage");
    public JLabel labelMenuMods = new JLabel("Mods");
    public JLabel labelMenuResources = new JLabel("Resources");
    public JLabel labelMenuConfig = new JLabel("Config");
    public JLabel labelMenuCreate = new JLabel("Create");
    public JLabel labelMenuSettings = new JLabel("Settings");
    public JLabel labelMenuAbout = new JLabel("About");

    public JLabel labelDataMods = new JLabel("400");
    public JLabel labelDataPacks = new JLabel("10");
    public JLabel labelDataSize = new JLabel(("5.7"));

    public JLabel labelTextMods = new JLabel("mods installed");
    public JLabel labelTextPacks = new JLabel("packs played");
    public JLabel labelTextTotal = new JLabel(("total"));
    public JLabel labelTextTotalTwo = new JLabel(("total"));
    public JLabel labelTextCurse = new JLabel(("Latest Mods"));
    public JLabel labelTextMinecraft = new JLabel(("Minecraft News"));
    public JLabel labelTextGB = new JLabel("GB");
    public JLabel labelTextTaken = new JLabel("Used");

    public JLabel labelHeader = new JLabel("<html>Welcome, <u><b>Lil Uzi Vert</u></b></html>");
    public JLabel labelSubheader = new JLabel("<html>You are currently playing <u><b>KannaCraft 3</u></b></html>");

    public JLabel labelLineOne = new JLabel((""));
    public JLabel labelLineTwo = new JLabel((""));
    public JLabel labelLineThree = new JLabel((""));
    public JLabel labelLineFour = new JLabel((""));
    public JLabel labelLineFive = new JLabel((""));
    public JLabel labelLineSix = new JLabel((""));
    public JLabel labelLineSeven = new JLabel((""));
    public JLabel labelLineMenu = new JLabel("");

    public JLabel imageLogo = new JLabel(new ImageIcon(this.getClass().getResource("/logoMaWTranspo.png")));
    public JLabel imageMosaic = new JLabel(new ImageIcon(this.getClass().getResource("/layoutMosaic.png")));

    public JLabel buttonHide = new JLabel(new ImageIcon(this.getClass().getResource("/iconHide_Small.png")));
    public JLabel buttonExit = new JLabel(new ImageIcon(this.getClass().getResource("/iconExit_Small.png")));
    public JLabel iconHome = new JLabel(new ImageIcon(this.getClass().getResource("/iconHome_Small.png")));
    public JLabel iconInstall = new JLabel(new ImageIcon(this.getClass().getResource("/iconInstall_Small.png")));
    public JLabel iconManage = new JLabel(new ImageIcon(this.getClass().getResource("/iconManage_Small.png")));
    public JLabel iconMods = new JLabel(new ImageIcon(this.getClass().getResource("/iconMods_Small.png")));
    public JLabel iconResources = new JLabel(new ImageIcon(this.getClass().getResource("/iconResources_small.png")));
    public JLabel iconConfig = new JLabel(new ImageIcon(this.getClass().getResource("/iconConfig_small.png")));
    public JLabel iconCreate = new JLabel(new ImageIcon(this.getClass().getResource("/iconCreate_small.png")));
    public JLabel iconSettings = new JLabel(new ImageIcon(this.getClass().getResource("/iconSettings_small.png")));
    public JLabel iconAbout = new JLabel(new ImageIcon(this.getClass().getResource("/iconAbout_small.png")));

    public JLayeredPane paneLayers;
    public Font fontMenu;
    public Font fontHeader;
    public Font fontSubheader;
    public Font fontBigData;
    public Font fontTinyData;
    public Font fontCategory;
    public Font fontSmallBubbleOne;
    public Font fontSmallBubbleTwo;
    public Font fontSmallBubbleThree;
    public Font fontAboutInformation;

    //About Variables
    public JLabel labelAboutHeader = new JLabel("ModsAtWork by LukaSong");
    public JLabel labelAboutInformation = new JLabel("" +
            "<html>" +
            "some stuff will go here :)" +
            "</html>");

    public JLabel imageAboutConfetti = new JLabel(new ImageIcon(this.getClass().getResource("/emojiConfetti_Twemoji.png")));

    //Misc Variables
    public String strFocusedTab = "dashboard";

    public Home(){
        paneLayers = getLayeredPane();
        setTitle("luka#8375 mods at work!");
        setSize(1050,650);
        Dimension dim = Toolkit.getDefaultToolkit().getScreenSize();
        setLocation(dim.width/2-this.getSize().width/2, dim.height/2-this.getSize().height/2);
        setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        setUndecorated(true);
        setLayout(null);
        setResizable(true);
        setBackground(Color.BLACK);
        getContentPane().setBackground(colorBackground);
        repaint();
        initFont();
        initComponent();
        initComponentDashboard();
        initComponentAbout();
        initEvent();
        initLayers();
        initDraggable();
        initStage();
        eventShift("about");
    }

    private void initDraggable(){
        FrameDragListener frameDragListener = new FrameDragListener(this);
        this.addMouseListener(frameDragListener);
        this.addMouseMotionListener(frameDragListener);
    }

    private void initFont(){
        try {
            fontMenu = Font.createFont(Font.TRUETYPE_FONT, new File(ClassLoader.getSystemClassLoader().getResource("fontRailway.otf").getFile())).deriveFont(24f);
            GraphicsEnvironment ge = GraphicsEnvironment.getLocalGraphicsEnvironment();
            ge.registerFont(fontMenu);
        } catch (Exception e){
            System.out.println(e);
        }
        try {
            fontHeader = Font.createFont(Font.TRUETYPE_FONT, new File(ClassLoader.getSystemClassLoader().getResource("fontRailway.otf").getFile())).deriveFont(42f);
            GraphicsEnvironment ge = GraphicsEnvironment.getLocalGraphicsEnvironment();
            ge.registerFont(fontHeader);
        } catch (Exception e){
            System.out.println(e);
        }
        try {
            fontSubheader = Font.createFont(Font.TRUETYPE_FONT, new File(ClassLoader.getSystemClassLoader().getResource("fontRailway.otf").getFile())).deriveFont(32f);
            GraphicsEnvironment ge = GraphicsEnvironment.getLocalGraphicsEnvironment();
            ge.registerFont(fontSubheader);
        } catch (Exception e){
            System.out.println(e);
        }
        try {
            fontBigData = Font.createFont(Font.TRUETYPE_FONT, new File(ClassLoader.getSystemClassLoader().getResource("fontRailway.otf").getFile())).deriveFont(112f);
            GraphicsEnvironment ge = GraphicsEnvironment.getLocalGraphicsEnvironment();
            ge.registerFont(fontBigData);
        } catch (Exception e){
            System.out.println(e);
        }
        try {
            fontTinyData = Font.createFont(Font.TRUETYPE_FONT, new File(ClassLoader.getSystemClassLoader().getResource("fontRailway.otf").getFile())).deriveFont(42f);
            GraphicsEnvironment ge = GraphicsEnvironment.getLocalGraphicsEnvironment();
            ge.registerFont(fontTinyData);
        } catch (Exception e){
            System.out.println(e);
        }
        try {
            fontCategory = Font.createFont(Font.TRUETYPE_FONT, new File(ClassLoader.getSystemClassLoader().getResource("fontRailway.otf").getFile())).deriveFont(20f);
            GraphicsEnvironment ge = GraphicsEnvironment.getLocalGraphicsEnvironment();
            ge.registerFont(fontCategory);
        } catch (Exception e){
            System.out.println(e);
        }
        try {
            fontSmallBubbleOne = Font.createFont(Font.TRUETYPE_FONT, new File(ClassLoader.getSystemClassLoader().getResource("fontRailway.otf").getFile())).deriveFont(64f);
            GraphicsEnvironment ge = GraphicsEnvironment.getLocalGraphicsEnvironment();
            ge.registerFont(fontSmallBubbleOne);
        } catch (Exception e){
            System.out.println(e);
        }
        try {
            fontSmallBubbleTwo = Font.createFont(Font.TRUETYPE_FONT, new File(ClassLoader.getSystemClassLoader().getResource("fontRailway.otf").getFile())).deriveFont(42f);
            GraphicsEnvironment ge = GraphicsEnvironment.getLocalGraphicsEnvironment();
            ge.registerFont(fontSmallBubbleTwo);
        } catch (Exception e){
            System.out.println(e);
        }
        try {
            fontSmallBubbleThree = Font.createFont(Font.TRUETYPE_FONT, new File(ClassLoader.getSystemClassLoader().getResource("fontRailway.otf").getFile())).deriveFont(32f);
            GraphicsEnvironment ge = GraphicsEnvironment.getLocalGraphicsEnvironment();
            ge.registerFont(fontSmallBubbleThree);
        } catch (Exception e){
            System.out.println(e);
        }
        try {
            fontAboutInformation = Font.createFont(Font.TRUETYPE_FONT, new File(ClassLoader.getSystemClassLoader().getResource("fontRailway.otf").getFile())).deriveFont(22f);
            GraphicsEnvironment ge = GraphicsEnvironment.getLocalGraphicsEnvironment();
            ge.registerFont(fontAboutInformation);
        } catch (Exception e){
            System.out.println(e);
        }
    }

    private void initComponent(){
        labelFauxTitle.setOpaque(true);
        labelFauxTitle.setBackground(colorAccent);
        labelFauxTitle.setBounds(0, 0, 1050, 50);
        labelFauxTitle.setHorizontalAlignment(SwingConstants.CENTER);

        labelFauxMenu.setOpaque(true);
        labelFauxMenu.setBackground(colorAccent);
        labelFauxMenu.setBounds(0, 0, 175, 650);
        labelFauxMenu.setHorizontalAlignment(SwingConstants.CENTER);

        buttonHide.setBounds(980, 12, 25, 25);
        buttonHide.setHorizontalAlignment(SwingConstants.CENTER);

        buttonExit.setBounds(1010, 12, 25, 25);
        buttonExit.setHorizontalAlignment(SwingConstants.CENTER);

        labelMenuDashboard.setBounds(13, 200, 175, 45);
        labelMenuDashboard.setHorizontalAlignment(SwingConstants.CENTER);
        labelMenuDashboard.setFont(fontMenu);
        labelMenuDashboard.setForeground(colorMenu);

        labelMenuInstall.setBounds(-7, 235, 175, 45);
        labelMenuInstall.setHorizontalAlignment(SwingConstants.CENTER);
        labelMenuInstall.setFont(fontMenu);
        labelMenuInstall.setForeground(colorMenu);

        labelMenuManage.setBounds(-1, 270, 175, 45);
        labelMenuManage.setHorizontalAlignment(SwingConstants.CENTER);
        labelMenuManage.setFont(fontMenu);
        labelMenuManage.setForeground(colorMenu);

        labelMenuMods.setBounds(-12, 305, 175, 45);
        labelMenuMods.setHorizontalAlignment(SwingConstants.CENTER);
        labelMenuMods.setFont(fontMenu);
        labelMenuMods.setForeground(colorMenu);

        labelMenuResources.setBounds(14, 340, 175, 45);
        labelMenuResources.setHorizontalAlignment(SwingConstants.CENTER);
        labelMenuResources.setFont(fontMenu);
        labelMenuResources.setForeground(colorMenu);

        labelMenuConfig.setBounds(-5, 375, 175, 45);
        labelMenuConfig.setHorizontalAlignment(SwingConstants.CENTER);
        labelMenuConfig.setFont(fontMenu);
        labelMenuConfig.setForeground(colorMenu);

        labelMenuCreate.setBounds(-3, 445, 175, 45);
        labelMenuCreate.setHorizontalAlignment(SwingConstants.CENTER);
        labelMenuCreate.setFont(fontMenu);
        labelMenuCreate.setForeground(colorMenu);

        labelMenuSettings.setBounds(4, 480, 175, 45);
        labelMenuSettings.setHorizontalAlignment(SwingConstants.CENTER);
        labelMenuSettings.setFont(fontMenu);
        labelMenuSettings.setForeground(colorMenu);

        labelMenuAbout.setBounds(-7, 515, 175, 45);
        labelMenuAbout.setHorizontalAlignment(SwingConstants.CENTER);
        labelMenuAbout.setFont(fontMenu);
        labelMenuAbout.setForeground(colorMenu);

        imageLogo.setOpaque(false);
        imageLogo.setBounds(0, -5, 175, 176);
        imageLogo.setHorizontalAlignment(SwingConstants.CENTER);

        labelLineMenu.setOpaque(true);
        labelLineMenu.setBackground(colorMenu);
        labelLineMenu.setBounds(16, 440, 144, 3);
        labelLineMenu.setHorizontalAlignment(SwingConstants.CENTER);

        iconHome.setBounds(17, 210, 24, 24);
        iconHome.setHorizontalAlignment(SwingConstants.CENTER);

        iconInstall.setBounds(17, 246, 24, 24);
        iconInstall.setHorizontalAlignment(SwingConstants.CENTER);

        iconManage.setBounds(17, 286, 24, 24);
        iconManage.setHorizontalAlignment(SwingConstants.CENTER);

        iconMods.setBounds(17, 321, 24, 24);
        iconMods.setHorizontalAlignment(SwingConstants.CENTER);

        iconResources.setBounds(17, 356, 24, 24);
        iconResources.setHorizontalAlignment(SwingConstants.CENTER);

        iconConfig.setBounds(17, 391, 24, 24);
        iconConfig.setHorizontalAlignment(SwingConstants.CENTER);

        iconCreate.setBounds(17, 460, 24, 24);
        iconCreate.setHorizontalAlignment(SwingConstants.CENTER);

        iconSettings.setBounds(17, 493, 24, 24);
        iconSettings.setHorizontalAlignment(SwingConstants.CENTER);

        iconAbout.setBounds(17, 528, 24, 24);
        iconAbout.setHorizontalAlignment(SwingConstants.CENTER);
    }

    private void initComponentDashboard(){
        imageMosaic.setOpaque(false);
        imageMosaic.setBounds(185, 175, 851, 422);
        imageMosaic.setHorizontalAlignment(SwingConstants.CENTER);

        labelHeader.setBounds(-355, -25, 1500, 200);
        labelHeader.setHorizontalAlignment(SwingConstants.CENTER);
        labelHeader.setFont(fontHeader);
        labelHeader.setForeground(colorMenu);

        labelSubheader.setBounds(-275, 25, 1500, 200);
        labelSubheader.setHorizontalAlignment(SwingConstants.CENTER);
        labelSubheader.setFont(fontSubheader);
        labelSubheader.setForeground(colorMenu);

        labelLineOne.setOpaque(true);
        labelLineOne.setBackground(colorMenuAccent);
        labelLineOne.setBounds(225, 450, 250, 3);
        labelLineOne.setHorizontalAlignment(SwingConstants.CENTER);

        labelLineTwo.setOpaque(true);
        labelLineTwo.setBackground(colorMenuAccent);
        labelLineTwo.setBounds(555, 450, 250, 3);
        labelLineTwo.setHorizontalAlignment(SwingConstants.CENTER);

        labelLineThree.setOpaque(true);
        labelLineThree.setBackground(colorMenuAccent);
        labelLineThree.setBounds(865, 435, 150, 3);
        labelLineThree.setHorizontalAlignment(SwingConstants.CENTER);

        labelLineFour.setOpaque(true);
        labelLineFour.setBackground(colorMenuAccent);
        labelLineFour.setBounds(865, 215, 150, 3);
        labelLineFour.setHorizontalAlignment(SwingConstants.CENTER);

        labelLineFive.setOpaque(true);
        labelLineFive.setBackground(colorMenuAccent);
        labelLineFive.setBounds(210, 503, 2, 75);
        labelLineFive.setHorizontalAlignment(SwingConstants.CENTER);

        labelLineSix.setOpaque(true);
        labelLineSix.setBackground(colorMenuAccent);
        labelLineSix.setBounds(430, 503, 2, 75);
        labelLineSix.setHorizontalAlignment(SwingConstants.CENTER);

        labelLineSeven.setOpaque(true);
        labelLineSeven.setBackground(colorMenuAccent);
        labelLineSeven.setBounds(650, 503, 2, 75);
        labelLineSeven.setHorizontalAlignment(SwingConstants.CENTER);

        labelDataMods.setBounds(155, 100, 400, 300);
        labelDataMods.setHorizontalAlignment(SwingConstants.CENTER);
        labelDataMods.setFont(fontBigData);
        labelDataMods.setForeground(colorMenu);

        labelTextMods.setBounds(155, 250, 400, 300);
        labelTextMods.setHorizontalAlignment(SwingConstants.CENTER);
        labelTextMods.setFont(fontTinyData);
        labelTextMods.setForeground(colorMenu);

        labelTextTotal.setBounds(155, 215, 400, 300);
        labelTextTotal.setHorizontalAlignment(SwingConstants.CENTER);
        labelTextTotal.setFont(fontTinyData);
        labelTextTotal.setForeground(colorMenu);

        labelDataPacks.setBounds(485, 100, 400, 300);
        labelDataPacks.setHorizontalAlignment(SwingConstants.CENTER);
        labelDataPacks.setFont(fontBigData);
        labelDataPacks.setForeground(colorMenu);

        labelTextPacks.setBounds(485, 250, 400, 300);
        labelTextPacks.setHorizontalAlignment(SwingConstants.CENTER);
        labelTextPacks.setFont(fontTinyData);
        labelTextPacks.setForeground(colorMenu);

        labelTextTotalTwo.setBounds(485, 215, 400, 300);
        labelTextTotalTwo.setHorizontalAlignment(SwingConstants.CENTER);
        labelTextTotalTwo.setFont(fontTinyData);
        labelTextTotalTwo.setForeground(colorMenu);

        labelTextCurse.setBounds(740, 45, 400, 300);
        labelTextCurse.setHorizontalAlignment(SwingConstants.CENTER);
        labelTextCurse.setFont(fontCategory);
        labelTextCurse.setForeground(colorMenu);

        labelTextMinecraft.setBounds(740, 265, 400, 300);
        labelTextMinecraft.setHorizontalAlignment(SwingConstants.CENTER);
        labelTextMinecraft.setFont(fontCategory);
        labelTextMinecraft.setForeground(colorMenu);

        labelDataSize.setBounds(498, 385, 400, 300);
        labelDataSize.setHorizontalAlignment(SwingConstants.CENTER);
        labelDataSize.setFont(fontSmallBubbleOne);
        labelDataSize.setForeground(colorMenu);

        labelTextGB.setBounds(568, 380, 400, 300);
        labelTextGB.setHorizontalAlignment(SwingConstants.CENTER);
        labelTextGB.setFont(fontSmallBubbleTwo);
        labelTextGB.setForeground(colorMenu);

        labelTextTaken.setBounds(590, 420, 400, 300);
        labelTextTaken.setHorizontalAlignment(SwingConstants.CENTER);
        labelTextTaken.setFont(fontSmallBubbleThree);
        labelTextTaken.setForeground(colorMenu);
    }

    private void initComponentAbout(){
        labelAboutHeader.setBounds(-320, -25, 1500, 200);
        labelAboutHeader.setHorizontalAlignment(SwingConstants.CENTER);
        labelAboutHeader.setFont(fontHeader);
        labelAboutHeader.setForeground(colorMenu);

        labelAboutInformation.setBounds(-435, 25, 1500, 200);
        labelAboutInformation.setHorizontalAlignment(SwingConstants.CENTER);
        labelAboutInformation.setFont(fontAboutInformation);
        labelAboutInformation.setForeground(colorMenu);

        imageAboutConfetti.setBounds(640, 5, 150, 150);
        imageAboutConfetti.setHorizontalAlignment(SwingConstants.CENTER);
    }

    private void initLayers(){
        paneLayers.add(labelFauxTitle, new Integer(1));
        paneLayers.add(labelFauxMenu, new Integer(0));
        paneLayers.add(buttonHide, new Integer(3));
        paneLayers.add(buttonExit, new Integer(3));
        paneLayers.add(labelMenuDashboard, new Integer(2));
        paneLayers.add(labelMenuInstall, new Integer(2));
        paneLayers.add(labelMenuManage, new Integer(2));
        paneLayers.add(labelMenuMods, new Integer(2));
        paneLayers.add(labelMenuResources, new Integer(2));
        paneLayers.add(labelMenuConfig, new Integer(2));
        paneLayers.add(labelMenuCreate, new Integer(2));
        paneLayers.add(labelMenuSettings, new Integer(2));
        paneLayers.add(labelMenuAbout, new Integer(2));
        paneLayers.add(imageLogo, new Integer(2));
        paneLayers.add(imageMosaic, new Integer(1));
        paneLayers.add(labelHeader, new Integer(2));
        paneLayers.add(labelSubheader, new Integer(2));
        paneLayers.add(labelSubheader, new Integer((2)));
        paneLayers.add(labelLineOne, new Integer(3));
        paneLayers.add(labelLineTwo, new Integer(3));
        paneLayers.add(labelLineThree, new Integer(3));
        paneLayers.add(labelLineFour, new Integer(3));
        paneLayers.add(labelLineFive, new Integer(3));
        paneLayers.add(labelLineSix, new Integer(3));
        paneLayers.add(labelLineSeven, new Integer(3));
        paneLayers.add(labelLineMenu, new Integer((3)));
        paneLayers.add(iconHome, new Integer(3));
        paneLayers.add(iconInstall, new Integer(3));
        paneLayers.add(iconManage, new Integer(3));
        paneLayers.add(iconMods, new Integer(3));
        paneLayers.add(iconResources, new Integer(3));
        paneLayers.add(iconConfig, new Integer(3));
        paneLayers.add(iconCreate, new Integer(3));
        paneLayers.add(iconSettings, new Integer(3));
        paneLayers.add(iconAbout, new Integer(3));
        paneLayers.add(labelDataMods, new Integer(3));
        paneLayers.add(labelTextMods, new Integer((3)));
        paneLayers.add(labelTextTotal, new Integer((3)));
        paneLayers.add(labelDataPacks, new Integer(3));
        paneLayers.add(labelTextPacks, new Integer((3)));
        paneLayers.add(labelTextTotalTwo, new Integer((3)));
        paneLayers.add(labelTextCurse, new Integer((3)));
        paneLayers.add(labelTextMinecraft, new Integer((3)));
        paneLayers.add(labelDataSize, new Integer((3)));
        paneLayers.add(labelTextGB, new Integer((3)));
        paneLayers.add(labelAboutHeader, new Integer((3)));
        paneLayers.add(labelAboutInformation, new Integer(3));
        paneLayers.add(imageAboutConfetti, new Integer(3));
    }

    private void initStage(){
        labelMenuInstall.setForeground(colorMenuBokeh);
        labelMenuManage.setForeground(colorMenuBokeh);
        labelMenuMods.setForeground(colorMenuBokeh);
        labelMenuResources.setForeground(colorMenuBokeh);
        labelMenuConfig.setForeground(colorMenuBokeh);
        labelMenuCreate.setForeground(colorMenuBokeh);
        labelMenuSettings.setForeground(colorMenuBokeh);
        labelMenuAbout.setForeground(colorMenuBokeh);
        iconInstall.setVisible(false);
        iconManage.setVisible(false);
        iconMods.setVisible(false);
        iconResources.setVisible(false);
        iconConfig.setVisible(false);
        iconCreate.setVisible(false);
        iconSettings.setVisible(false);
        iconAbout.setVisible(false);
        labelAboutHeader.setVisible(false);
        labelAboutInformation.setVisible(false);
        imageAboutConfetti.setVisible(false);
    }

    private void initEvent(){
        //<editor-fold desc="standard actions">
        this.addWindowListener(new WindowAdapter() {
            public void windowClosing(WindowEvent e){
                System.exit(1);
            }
        });

        buttonExit.addMouseListener(new MouseAdapter()
        {
            public void mouseClicked(MouseEvent e)
            {
                System.exit(1);
            }
        });
        //</editor-fold>

        //<editor-fold desc="hover effects">
        labelMenuDashboard.addMouseListener(new java.awt.event.MouseAdapter() {
            public void mouseEntered(java.awt.event.MouseEvent evt) {
                if(!strFocusedTab.equals("dashboard")) {
                    labelMenuDashboard.setForeground(colorMenu);
                    labelMenuDashboard.repaint();
                }
            }

            public void mouseExited(java.awt.event.MouseEvent evt) {
                if(!strFocusedTab.equals("dashboard")) {
                    labelMenuDashboard.setForeground(colorMenuBokeh);
                    labelMenuDashboard.repaint();
                }
            }
        });

        labelMenuInstall.addMouseListener(new java.awt.event.MouseAdapter() {
            public void mouseEntered(java.awt.event.MouseEvent evt) {
                if(!strFocusedTab.equals("install")) {
                    labelMenuInstall.setForeground(colorMenu);
                    labelMenuInstall.repaint();
                }
            }

            public void mouseExited(java.awt.event.MouseEvent evt) {
                if(!strFocusedTab.equals("install")) {
                    labelMenuInstall.setForeground(colorMenuBokeh);
                    labelMenuInstall.repaint();
                }
            }
        });

        labelMenuManage.addMouseListener(new java.awt.event.MouseAdapter() {
            public void mouseEntered(java.awt.event.MouseEvent evt) {
                if(!strFocusedTab.equals("manage")) {
                    labelMenuManage.setForeground(colorMenu);
                    labelMenuManage.repaint();
                }
            }

            public void mouseExited(java.awt.event.MouseEvent evt) {
                if(!strFocusedTab.equals("manage")) {
                    labelMenuManage.setForeground(colorMenuBokeh);
                    labelMenuManage.repaint();
                }
            }
        });

        labelMenuMods.addMouseListener(new java.awt.event.MouseAdapter() {
            public void mouseEntered(java.awt.event.MouseEvent evt) {
                if(!strFocusedTab.equals("mods")) {
                    labelMenuMods.setForeground(colorMenu);
                    labelMenuMods.repaint();
                }
            }

            public void mouseExited(java.awt.event.MouseEvent evt) {
                if(!strFocusedTab.equals("mods")) {
                    labelMenuMods.setForeground(colorMenuBokeh);
                    labelMenuMods.repaint();
                }
            }
        });

        labelMenuResources.addMouseListener(new java.awt.event.MouseAdapter() {
            public void mouseEntered(java.awt.event.MouseEvent evt) {
                if(!strFocusedTab.equals("resources")) {
                    labelMenuResources.setForeground(colorMenu);
                    labelMenuResources.repaint();
                }
            }

            public void mouseExited(java.awt.event.MouseEvent evt) {
                if(!strFocusedTab.equals("resources")) {
                    labelMenuResources.setForeground(colorMenuBokeh);
                    labelMenuResources.repaint();
                }
            }
        });

        labelMenuConfig.addMouseListener(new java.awt.event.MouseAdapter() {
            public void mouseEntered(java.awt.event.MouseEvent evt) {
                if(!strFocusedTab.equals("config")) {
                    labelMenuConfig.setForeground(colorMenu);
                    labelMenuConfig.repaint();
                }
            }

            public void mouseExited(java.awt.event.MouseEvent evt) {
                if(!strFocusedTab.equals("config")) {
                    labelMenuConfig.setForeground(colorMenuBokeh);
                    labelMenuConfig.repaint();
                }
            }
        });

        labelMenuCreate.addMouseListener(new java.awt.event.MouseAdapter() {
            public void mouseEntered(java.awt.event.MouseEvent evt) {
                if(!strFocusedTab.equals("create")) {
                    labelMenuCreate.setForeground(colorMenu);
                    labelMenuCreate.repaint();
                }
            }

            public void mouseExited(java.awt.event.MouseEvent evt) {
                if(!strFocusedTab.equals("create")) {
                    labelMenuCreate.setForeground(colorMenuBokeh);
                    labelMenuCreate.repaint();
                }
            }
        });

        labelMenuSettings.addMouseListener(new java.awt.event.MouseAdapter() {
            public void mouseEntered(java.awt.event.MouseEvent evt) {
                if(!strFocusedTab.equals("settings")) {
                    labelMenuSettings.setForeground(colorMenu);
                    labelMenuSettings.repaint();
                }
            }

            public void mouseExited(java.awt.event.MouseEvent evt) {
                if(!strFocusedTab.equals("settings")) {
                    labelMenuSettings.setForeground(colorMenuBokeh);
                    labelMenuSettings.repaint();
                }
            }
        });

        labelMenuAbout.addMouseListener(new java.awt.event.MouseAdapter() {
            public void mouseEntered(java.awt.event.MouseEvent evt) {
                if(!strFocusedTab.equals("about")) {
                    labelMenuAbout.setForeground(colorMenu);
                    labelMenuAbout.repaint();
                }
            }

            public void mouseExited(java.awt.event.MouseEvent evt) {
                if(!strFocusedTab.equals("about")) {
                    labelMenuAbout.setForeground(colorMenuBokeh);
                    labelMenuAbout.repaint();
                }
            }
        });
        //</editor-fold>

        //<editor-fold desc="click focus">
        labelMenuDashboard.addMouseListener(new MouseAdapter()
        {
            public void mouseClicked(MouseEvent e)
            {
                eventShift("dashboard");
            }
        });

        labelMenuInstall.addMouseListener(new MouseAdapter()
        {
            public void mouseClicked(MouseEvent e)
            {
                eventShift("install");
            }
        });

        labelMenuManage.addMouseListener(new MouseAdapter()
        {
            public void mouseClicked(MouseEvent e)
            {
                eventShift("manage");
            }
        });

        labelMenuMods.addMouseListener(new MouseAdapter()
        {
            public void mouseClicked(MouseEvent e)
            {
                eventShift("mods");
            }
        });

        labelMenuResources.addMouseListener(new MouseAdapter()
        {
            public void mouseClicked(MouseEvent e)
            {
                eventShift("resources");
            }
        });

        labelMenuConfig.addMouseListener(new MouseAdapter()
        {
            public void mouseClicked(MouseEvent e)
            {
                eventShift("config");
            }
        });

        labelMenuCreate.addMouseListener(new MouseAdapter()
        {
            public void mouseClicked(MouseEvent e)
            {
                eventShift("create");
            }
        });

        labelMenuSettings.addMouseListener(new MouseAdapter()
        {
            public void mouseClicked(MouseEvent e)
            {
                eventShift("settings");
            }
        });

        labelMenuAbout.addMouseListener(new MouseAdapter()
        {
            public void mouseClicked(MouseEvent e)
            {
                eventShift("about");
            }
        });
        //</editor-fold>
    }

    private void eventShift(String strNewTab){
        switch(strFocusedTab){
            case "dashboard":
                labelMenuDashboard.setForeground(colorMenuBokeh);
                iconHome.setVisible(false);
                imageMosaic.setVisible(false);
                labelHeader.setVisible(false);
                labelSubheader.setVisible(false);
                labelLineOne.setVisible(false);
                labelLineTwo.setVisible(false);
                labelLineThree.setVisible(false);
                labelLineFour.setVisible(false);
                labelLineFive.setVisible(false);
                labelLineSix.setVisible(false);
                labelLineSeven.setVisible(false);
                labelDataMods.setVisible(false);
                labelTextMods.setVisible(false);
                labelTextMods.setVisible(false);
                labelTextTotal.setVisible(false);
                labelDataPacks.setVisible(false);
                labelTextPacks.setVisible(false);
                labelTextTotalTwo.setVisible(false);
                labelTextCurse.setVisible(false);
                labelTextMinecraft.setVisible(false);
                labelDataSize.setVisible(false);
                labelTextGB.setVisible(false);
                labelTextTaken.setVisible(false);
                break;
            case "install":
                labelMenuInstall.setForeground(colorMenuBokeh);
                iconInstall.setVisible(false);
                break;
            case "manage":
                labelMenuManage.setForeground(colorMenuBokeh);
                iconManage.setVisible(false);
                break;
            case "mods":
                labelMenuMods.setForeground(colorMenuBokeh);
                iconMods.setVisible(false);
                break;
            case "resources":
                labelMenuResources.setForeground(colorMenuBokeh);
                iconResources.setVisible(false);
                break;
            case "config":
                labelMenuConfig.setForeground(colorMenuBokeh);
                iconConfig.setVisible(false);
                break;
            case "create":
                labelMenuCreate.setForeground(colorMenuBokeh);
                iconCreate.setVisible(false);
                break;
            case "settings":
                labelMenuSettings.setForeground(colorMenuBokeh);
                iconSettings.setVisible(false);
                break;
            case "about":
                labelMenuAbout.setForeground(colorMenuBokeh);
                iconAbout.setVisible(false);
                labelAboutHeader.setVisible(false);
                labelAboutInformation.setVisible(false);
                imageAboutConfetti.setVisible(false);
                break;
            default:
                Main.lukaLog(1, "There was an error! I'm writing this code in a call while playing games so uh... makes sense there was an error :/");
        }
        switch(strNewTab){
            case "dashboard":
                labelMenuDashboard.setForeground(colorMenu);
                iconHome.setVisible(true);
                strFocusedTab = "dashboard";
                iconHome.setVisible(true);
                imageMosaic.setVisible(true);
                labelHeader.setVisible(true);
                labelSubheader.setVisible(true);
                labelLineOne.setVisible(true);
                labelLineTwo.setVisible(true);
                labelLineThree.setVisible(true);
                labelLineFour.setVisible(true);
                labelLineFive.setVisible(true);
                labelLineSix.setVisible(true);
                labelLineSeven.setVisible(true);
                labelDataMods.setVisible(true);
                labelTextMods.setVisible(true);
                labelTextMods.setVisible(true);
                labelTextTotal.setVisible(true);
                labelDataPacks.setVisible(true);
                labelTextPacks.setVisible(true);
                labelTextTotalTwo.setVisible(true);
                labelTextCurse.setVisible(true);
                labelTextMinecraft.setVisible(true);
                labelDataSize.setVisible(true);
                labelTextGB.setVisible(true);
                labelTextTaken.setVisible(true);
                break;
            case "install":
                labelMenuInstall.setForeground(colorMenu);
                iconInstall.setVisible(true);
                strFocusedTab = "install";
                break;
            case "manage":
                labelMenuManage.setForeground(colorMenu);
                iconManage.setVisible(true);
                strFocusedTab = "manage";
                break;
            case "mods":
                labelMenuMods.setForeground(colorMenu);
                iconMods.setVisible(true);
                strFocusedTab = "mods";
                break;
            case "resources":
                labelMenuResources.setForeground(colorMenu);
                iconResources.setVisible(true);
                strFocusedTab = "resources";
                break;
            case "config":
                labelMenuConfig.setForeground(colorMenu);
                iconConfig.setVisible(true);
                strFocusedTab = "config";
                break;
            case "create":
                labelMenuCreate.setForeground(colorMenu);
                iconCreate.setVisible(true);
                strFocusedTab = "create";
                break;
            case "settings":
                labelMenuSettings.setForeground(colorMenu);
                iconSettings.setVisible(true);
                strFocusedTab = "settings";
                break;
            case "about":
                labelMenuAbout.setForeground(colorMenu);
                iconAbout.setVisible(true);
                strFocusedTab = "about";
                labelAboutHeader.setVisible(true);
                labelAboutInformation.setVisible(true);
                imageAboutConfetti.setVisible(true);
                break;
            default:
                Main.lukaLog(1, "There was an error! I'm writing this code in a call while playing games so uh... makes sense there was an error :/");
        }
    }

    public static class FrameDragListener extends MouseAdapter {
        //https://stackoverflow.com/questions/16046824/making-a-java-swing-frame-movable-and-setundecorated
        private final JFrame frame;
        private Point mouseDownCompCoords = null;
        public FrameDragListener(JFrame frame) {
            this.frame = frame;
        }
        public void mouseReleased(MouseEvent e) {
            mouseDownCompCoords = null;
        }
        public void mousePressed(MouseEvent e) {
            mouseDownCompCoords = e.getPoint();
        }
        public void mouseDragged(MouseEvent e) {
            Point currCoords = e.getLocationOnScreen();
            frame.setLocation(currCoords.x - mouseDownCompCoords.x, currCoords.y - mouseDownCompCoords.y);
        }
    }


}
