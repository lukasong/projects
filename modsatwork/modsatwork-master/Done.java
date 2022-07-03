package me.lukasong.maw;

import javax.swing.*;
import java.awt.*;
import java.awt.event.*;
import java.io.File;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

class Done extends JFrame {

    private String divider = "--------------------------";

    private JButton btnApply = new JButton("close the installer");
    
    private JLabel labelPoggies;

    private JLabel labelHeader = new JLabel(Main.lukaRainbowfy("youre done!!!"));
    private JLabel labelFooter = new JLabel(Window.labelFooter.getText());
    private JLabel labelDivider = new JLabel(Main.applyWhite(divider+divider+divider));
    private JLabel labelAtWork = new JLabel(Main.applyWhite("enjoy the modpack c:"));

    private Color backgroundColor = new Color(44,47,51);



    public Done(){
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
        
        labelHeader.setBounds(20, 15, 600, 20);
        labelHeader.setHorizontalAlignment(SwingConstants.CENTER);
        labelDivider.setBounds(0, 40, 600, 20);
        labelDivider.setHorizontalAlignment(SwingConstants.CENTER);

        labelPoggies = new JLabel(new ImageIcon(this.getClass().getResource("/kannapoggies.png")));
        labelPoggies.setBounds(0, -35, 600,  400);
        labelAtWork.setBounds(0, 265, 600, 20);
        labelAtWork.setHorizontalAlignment(SwingConstants.CENTER);

        btnApply.setBounds(25, 300, 550, 20);
        btnApply.setHorizontalAlignment(SwingConstants.CENTER);

        labelFooter.setBounds(0, 340, 600, 20);
        labelFooter.setHorizontalAlignment(SwingConstants.CENTER);
        
        add(labelHeader);
        add(labelDivider);
        add(labelPoggies);
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
                System.exit(1);
            }
        });


    }
}
