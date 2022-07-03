package me.lukasong.maw;

import javax.swing.*;
import java.awt.*;
import java.awt.event.*;

class Backup extends JFrame {

    private String divider = "--------------------------";

    private JButton btnApply = new JButton("clean minecraft directory");

    private JLabel labelCircleOne;

    private JLabel labelHeader = new JLabel(Main.lukaRainbowfy("backup or remove previous modified files"));
    private JLabel labelFooter = new JLabel(Window.labelFooter.getText());
    private JLabel labelDivider = new JLabel(Main.applyWhite(divider+divider+divider));
    private JLabel labelInstructions = new JLabel(Main.applyWhite("if you have previously installed modded content on minecraft"));
    private JLabel labelInstructionsTwo = new JLabel(Main.applyWhite("and wish to keep your past files, select \"keep old files\","));
    private JLabel labelInstructionsThree = new JLabel(Main.applyWhite("if you wish to clean out your minecraft directory, choose the second option."));
    private JLabel labelInstructionsFour = new JLabel(Main.applyWhite("if you have have never installed mods before, it doesn't matter what you choose."));

    private JCheckBox cbKeep = new JCheckBox(Main.applyWhite("keep old modified files"));
    private JCheckBox cbClean = new JCheckBox(Main.applyWhite("delete and clean old modified files"));

    private Color backgroundColor = new Color(44,47,51);



    public Backup(){
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


        labelCircleOne = new JLabel(new ImageIcon(this.getClass().getResource("/lookaOne.png")));
        labelCircleOne.setBounds(75, 0, 200,  50);
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
        labelInstructionsFour.setBounds(0, 130, 600, 20);
        labelInstructionsFour.setHorizontalAlignment(SwingConstants.CENTER);

        cbKeep.setBounds(0, 190, 600, 20);
        cbKeep.setHorizontalAlignment(SwingConstants.CENTER);
        cbKeep.setBackground(backgroundColor);
        cbClean.setBounds(0, 210, 600, 20);
        cbClean.setHorizontalAlignment(SwingConstants.CENTER);
        cbClean.setBackground(backgroundColor);

        btnApply.setBounds(25, 300, 550, 20);
        btnApply.setHorizontalAlignment(SwingConstants.CENTER);

        labelFooter.setBounds(0, 340, 600, 20);
        labelFooter.setHorizontalAlignment(SwingConstants.CENTER);


        add(labelCircleOne);
        add(labelHeader);
        add(labelDivider);
        add(labelInstructions);
        add(labelInstructionsTwo);
        add(labelInstructionsThree);
        add(labelInstructionsFour);
        add(cbKeep);
        add(cbClean);
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
                Main.stepOne(cbClean.isSelected());
            }
        });


    }
}
