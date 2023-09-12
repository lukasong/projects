package me.lukasong.shaderobsf;

import sun.misc.JavaLangAccess;

import javax.swing.*;
import javax.swing.filechooser.FileNameExtensionFilter;
import java.awt.*;
import java.awt.event.*;

class Progress extends JFrame {

    public static JLabel labelHeader = new JLabel(Main.applyWhite("Obfuscation Progress"));
    public static JLabel labelStatus = new JLabel(Main.applyWhite("Starting.."));
    public static JLabel labelUmaru;
    public static JLabel labelUmaruInfo = new JLabel(Main.applyWhite("the progress bar isn't really working yet.."));
    public static JLabel labelUmaruInfoTwo = new JLabel(Main.applyWhite("so youll be updated here instead! : D"));
    public static JLabel labelUmaruStatus = new JLabel(Main.applyWhite("Done!! c:"));
    public static JProgressBar progressBar = new JProgressBar();




    public Progress(){
        setTitle("luka#8375 shader obfuscator");
        setSize(450,400);
        Dimension dim = Toolkit.getDefaultToolkit().getScreenSize();
        setLocation(dim.width/2-this.getSize().width/2, dim.height/2-this.getSize().height/2);
        setLayout(null);
        setResizable(false);
        setBackground(Color.BLACK);
        getContentPane().setBackground(new Color(44,47,51));
        setDefaultCloseOperation(JFrame.DISPOSE_ON_CLOSE);
        repaint();
        initComponent();
    }

    public static void updateProgress(String message, int increment){
        progressBar.setValue(increment);
        labelStatus.setText(Main.applyWhite(message));
        progressBar.repaint();
    }

    private void initComponent(){


        labelHeader.setBounds(0, 10, 400, 20);
        labelHeader.setHorizontalAlignment(SwingConstants.CENTER);
        progressBar.setBounds(25, 40, 350, 20);
        progressBar.setMinimum(0);
        progressBar.setMaximum(100);
        labelStatus.setBounds(0, 60, 400, 20);
        labelStatus.setHorizontalAlignment(SwingConstants.CENTER);
        //progressBar

        labelUmaru = new JLabel(new ImageIcon(this.getClass().getResource("/umaru_ds.png")));
        labelUmaruInfo.setBounds(25, 10, 400, 20);
        labelUmaruInfo.setHorizontalAlignment(SwingConstants.CENTER);
        labelUmaruInfoTwo.setBounds(25, 25, 400, 20);
        labelUmaruInfoTwo.setHorizontalAlignment(SwingConstants.CENTER);
        labelUmaru.setBounds(25, 20, 400,  320);
        labelUmaru.setHorizontalAlignment(SwingConstants.CENTER);
        labelUmaruStatus.setBounds(25, 325, 400, 20);
        labelUmaruStatus.setHorizontalAlignment(SwingConstants.CENTER);
        //umaru notifier

        add(labelUmaruInfo);
        add(labelUmaruInfoTwo);
        add(labelUmaru);
        add(labelUmaruStatus);

       // add(labelHeader);
        //add(progressBar);
        //add(labelStatus);

    }

}
