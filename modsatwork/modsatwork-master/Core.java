package me.lukasong.maw;

import javax.swing.*;
import java.awt.*;
import java.awt.event.*;
import java.io.File;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

class Core extends JFrame {

    private String divider = "--------------------------";

    private JButton btnApply = new JButton("transport core files to minecraft");

    private JLabel labelCircleFour;
    private JLabel labelPlatelets;

    private JLabel labelHeader = new JLabel(Main.lukaRainbowfy("transport core files"));
    private JLabel labelFooter = new JLabel(Window.labelFooter.getText());
    private JLabel labelDivider = new JLabel(Main.applyWhite(divider+divider+divider));
    private JLabel labelAtWork = new JLabel(Main.applyWhite("ready to transport!"));

    private Color backgroundColor = new Color(44,47,51);



    public Core(){
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

        labelCircleFour = new JLabel(new ImageIcon(this.getClass().getResource("/lookaFour.png")));
        labelCircleFour.setBounds(140, 0, 200,  50);
        labelHeader.setBounds(20, 15, 600, 20);
        labelHeader.setHorizontalAlignment(SwingConstants.CENTER);
        labelDivider.setBounds(0, 40, 600, 20);
        labelDivider.setHorizontalAlignment(SwingConstants.CENTER);

        labelPlatelets = new JLabel(new ImageIcon(this.getClass().getResource("/platelets.png")));
        labelPlatelets.setBounds(0, -35, 600,  400);
        labelAtWork.setBounds(0, 265, 600, 20);
        labelAtWork.setHorizontalAlignment(SwingConstants.CENTER);

        btnApply.setBounds(25, 300, 550, 20);
        btnApply.setHorizontalAlignment(SwingConstants.CENTER);

        labelFooter.setBounds(0, 340, 600, 20);
        labelFooter.setHorizontalAlignment(SwingConstants.CENTER);

        add(labelCircleFour);
        add(labelHeader);
        add(labelDivider);
        add(labelPlatelets);
        add(labelAtWork);
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
                try{
                    Main.stepFour();
                }catch(IOException i){
                    Main.lukaLog(1, "error running step four.. " + e + "\n...skipping step four.");
                    Main.fourthFrame.setVisible(false);
                    Main.fifthFrame = new Optional();
                    Main.fifthFrame.setVisible(true);
                }
            }
        });


    }
}
