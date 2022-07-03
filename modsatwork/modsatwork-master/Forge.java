package me.lukasong.maw;

import com.sun.jndi.toolkit.url.Uri;

import javax.swing.*;
import java.awt.*;
import java.awt.event.*;
import java.io.IOException;
import java.net.URI;

class Forge extends JFrame {

    private String divider = "--------------------------";

    private JButton btnApply = new JButton("run forge installer");
    private JButton btnSkip = new JButton("skip forge installation");
    private JButton btnCheck = new JButton("check if 64 bit is installed");
    private JButton btnInstall = new JButton("install 64 bit java here");

    private JLabel labelCircleTwo;

    private JLabel labelHeader = new JLabel(Main.lukaRainbowfy("install java and forge"));
    private JLabel labelFooter = new JLabel(Window.labelFooter.getText());
    private JLabel labelDivider = new JLabel(Main.applyWhite(divider+divider+divider));
    private JLabel labelInstructions = new JLabel(Main.applyWhite("minecraft runs best on java 64 bit!"));
    private JLabel labelInstructionsTwo = new JLabel(Main.applyWhite("your default java version: " + Main.getJavaType()));
    private JLabel labelInstructionsThree = new JLabel(Main.applyWhite(""));
    private JLabel labelInstructionsFour = new JLabel(Main.applyWhite("next, this will run the forge installer."));
    private JLabel labelInstructionsFive = new JLabel(Main.applyWhite("install as client, not server"));

    private Color backgroundColor = new Color(44,47,51);



    public Forge(){
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

        if(Main.getJavaType().contains("64")){
            labelInstructionsTwo = new JLabel(Main.applyWhite("your default java version: " + Main.getJavaType() + " (32 bit may be installed as well)"));
            labelInstructionsThree = new JLabel(Main.applyWhite("your java is ready to go!"));
        }else{
            labelInstructionsTwo = new JLabel(Main.applyWhite("your default java version: " + Main.getJavaType() + " (64 bit may be installed as well)"));
            labelInstructionsThree = new JLabel(Main.applyWhite("check out the links below to fix your java.."));
        }

        labelCircleTwo = new JLabel(new ImageIcon(this.getClass().getResource("/lookaTwo.png")));
        labelCircleTwo.setBounds(130, 0, 200,  50);
        labelHeader.setBounds(20, 15, 600, 20);
        labelHeader.setHorizontalAlignment(SwingConstants.CENTER);
        labelDivider.setBounds(0, 40, 600, 20);
        labelDivider.setHorizontalAlignment(SwingConstants.CENTER);

        labelInstructions.setBounds(0, 70, 600, 20);
        labelInstructions.setHorizontalAlignment(SwingConstants.CENTER);
        labelInstructionsTwo.setBounds(0, 90, 600, 20);
        labelInstructionsTwo.setHorizontalAlignment(SwingConstants.CENTER);
        labelInstructionsThree.setBounds(0, 110, 600, 20);
        labelInstructionsThree.setHorizontalAlignment(SwingConstants.CENTER);

        btnCheck.setBounds(100, 145, 400, 20);
        btnCheck.setHorizontalAlignment(SwingConstants.CENTER);
        btnInstall.setBounds(100, 165, 400, 20);
        btnInstall.setHorizontalAlignment(SwingConstants.CENTER);

        labelInstructionsFour.setBounds(0, 220, 600, 20);
        labelInstructionsFour.setHorizontalAlignment(SwingConstants.CENTER);
        labelInstructionsFive.setBounds(0, 240, 600, 20);
        labelInstructionsFive.setHorizontalAlignment(SwingConstants.CENTER);

        btnApply.setBounds(100, 280, 400, 20);
        btnApply.setHorizontalAlignment(SwingConstants.CENTER);
        btnSkip.setBounds(100, 305, 400, 20);
        btnSkip.setHorizontalAlignment(SwingConstants.CENTER);

        labelFooter.setBounds(0, 340, 600, 20);
        labelFooter.setHorizontalAlignment(SwingConstants.CENTER);


        add(labelCircleTwo);
        add(labelHeader);
        add(labelDivider);
        add(labelInstructions);
        add(labelInstructionsTwo);
        add(labelInstructionsThree);
        add(btnCheck);
        add(btnInstall);
        add(labelInstructionsFour);
        add(labelInstructionsFive);
        add(btnApply);
        add(btnSkip);
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
                try{
                    Main.stepTwo(false);
                }catch(Exception i){
                    Main.lukaLog(1, "failed to run step two");
                }
            }
        });

        btnSkip.addActionListener(new ActionListener() {
            @Override
            public void actionPerformed(ActionEvent e) {
                try{
                    Main.stepTwo(true);
                }catch(Exception i){
                    Main.lukaLog(1, "failed to run step two");
                }
            }
        });

        btnCheck.addActionListener(new ActionListener() {
            @Override
            public void actionPerformed(ActionEvent e) {
                URI checkLink = Main.newLink("https://superuser.com/questions/1221096/how-do-i-check-what-version-of-java-i-have-installed");
                Main.openLink(checkLink);
            }
        });

        btnInstall.addActionListener(new ActionListener() {
            @Override
            public void actionPerformed(ActionEvent e) {
                URI installLink = Main.newLink("https://java.com/en/download/faq/java_win64bit.xml#Java%20for%2064-bit");
                Main.openLink(installLink);
            }
        });


    }
}
