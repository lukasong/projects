package me.lukasong.maw;

import javax.swing.*;
import java.awt.*;
import java.awt.event.*;
import java.io.File;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

class Optional extends JFrame {

    private String divider = "--------------------------";

    private JButton btnApply = new JButton("install optional mods");

    private JLabel labelCircleFive;

    private JLabel labelHeader = new JLabel(Main.lukaRainbowfy("install optional mods"));
    private JLabel labelFooter = new JLabel(Window.labelFooter.getText());
    private JLabel labelDivider = new JLabel(Main.applyWhite(divider+divider+divider));
    private JLabel labelHelp = new JLabel(Main.applyWhite("dont know what a mod does? google it.. (pls)"));

    public static JCheckBox cbVisuals = new JCheckBox(Main.applyWhite("Visuals Mod"));
    public static JCheckBox cbMap = new JCheckBox(Main.applyWhite("JourneyMap"));
    public static JCheckBox cbClean = new JCheckBox(Main.applyWhite("CleanView"));
    public static JCheckBox cbNeat = new JCheckBox(Main.applyWhite("Neat"));
    public static JCheckBox cbRecipe = new JCheckBox(Main.applyWhite("FullScreenWindowed"));
    public static JCheckBox cbSound = new JCheckBox(Main.applyWhite("Sound Filters"));
    public static JCheckBox cbYarr = new JCheckBox(Main.applyWhite("Cute Mob Models"));
    public static JCheckBox cbAmbient = new JCheckBox(Main.applyWhite("Ambient Sounds"));
    public static JCheckBox cbFancy = new JCheckBox(Main.applyWhite("Hwyla"));
    public static JCheckBox cbHealth = new JCheckBox(Main.applyWhite("Colorful Health"));
    public static JCheckBox cbDynamic = new JCheckBox(Main.applyWhite("Dynamic Surroundings"));
    public static JCheckBox cbClient = new JCheckBox(Main.applyWhite("Mouse Tweaks"));
    public static JCheckBox cbControl = new JCheckBox(Main.applyWhite("Smooth Font"));
    public static JCheckBox cbFoilage = new JCheckBox(Main.applyWhite("Better Foilage"));

    private Color backgroundColor = new Color(44,47,51);



    public Optional(){
        setTitle("luka#8375 mods at work!");
        setSize(600,400);
        Dimension dim = Toolkit.getDefaultToolkit().getScreenSize();
        setLocation(dim.width/2-this.getSize().width/2, dim.height/2-this.getSize().height/2);
        setLayout(null);
        setResizable(false);
        setBackground(Color.BLACK);
        getContentPane().setBackground(backgroundColor);
        repaint();
        initComponent();
        initEvent();
    }

    private void initComponent(){

        labelCircleFive = new JLabel(new ImageIcon(this.getClass().getResource("/lookaFive.png")));
        labelCircleFive.setBounds(135, 0, 200,  50);
        labelHeader.setBounds(20, 15, 600, 20);
        labelHeader.setHorizontalAlignment(SwingConstants.CENTER);
        labelDivider.setBounds(0, 40, 600, 20);
        labelDivider.setHorizontalAlignment(SwingConstants.CENTER);
        labelHelp.setBounds(0, 60, 600, 20);
        labelHelp.setHorizontalAlignment(SwingConstants.CENTER);

        cbVisuals.setBounds(50, 100, 100, 20);
        cbVisuals.setBackground(backgroundColor);
        cbMap.setBounds(50, 120, 100, 20);
        cbMap.setBackground(backgroundColor);
        cbClean.setBounds(50, 140, 100, 20);
        cbClean.setBackground(backgroundColor);
        cbNeat.setBounds(50, 160, 100, 20);
        cbNeat.setBackground(backgroundColor);
        cbRecipe.setBounds(50, 180, 200, 20);
        cbRecipe.setBackground(backgroundColor);
        cbSound.setBounds(50, 200, 100, 20);
        cbSound.setBackground(backgroundColor);
        cbYarr.setBounds(50, 220, 200, 20);
        cbYarr.setBackground(backgroundColor);

        cbAmbient.setBounds(400, 100, 200, 20);
        cbAmbient.setBackground(backgroundColor);
        cbFancy.setBounds(400, 120, 200, 20);
        cbFancy.setBackground(backgroundColor);
        cbHealth.setBounds(400, 140, 200, 20);
        cbHealth.setBackground(backgroundColor);
        cbDynamic.setBounds(400, 160, 200, 20);
        cbDynamic.setBackground(backgroundColor);
        cbClient.setBounds(400, 180, 200, 20);
        cbClient.setBackground(backgroundColor);
        cbControl.setBounds(400, 200, 200, 20);
        cbControl.setBackground(backgroundColor);
        cbFoilage.setBounds(400, 220, 200, 20);
        cbFoilage.setBackground(backgroundColor);

        btnApply.setBounds(25, 300, 550, 20);
        btnApply.setHorizontalAlignment(SwingConstants.CENTER);

        labelFooter.setBounds(0, 340, 600, 20);
        labelFooter.setHorizontalAlignment(SwingConstants.CENTER);

        add(labelCircleFive);
        add(labelHeader);
        add(labelDivider);
        add(labelHelp);
        add(cbVisuals);
        add(cbMap);
        add(cbClean);
        add(cbNeat);
        add(cbRecipe);
        add(cbSound);
        add(cbYarr);
        add(cbAmbient);
        add(cbFancy);
        add(cbHealth);
        add(cbDynamic);
        add(cbClient);
        add(cbControl);
        add(cbFoilage);
        add(btnApply);
        add(labelFooter);


    }

    private void initEvent(){

        this.addWindowListener(new WindowAdapter() {
            public void windowClosing(WindowEvent e){
                System.exit(1);
            }
        });

        btnApply.addActionListener(new ActionListener() {
            @Override
            public void actionPerformed(ActionEvent e) {
                try {
                    Main.stepFive();
                }catch(IOException i){
                    Main.lukaLog(1, "error running step five.. " + e + "\n...skipping step five.");
                    Main.fifthFrame.setVisible(false);
                    Main.endFrame = new Done();
                    Main.endFrame.setVisible(true);
                }
            }
        });


    }
}
