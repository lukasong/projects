package me.lukasong.maw;

import javax.swing.*;
import java.awt.*;
import java.awt.event.*;

class Window extends JFrame {

    private String divider = "--------------------------";

    private JButton btnApply = new JButton("charge your minecraft");
    private JButton btnUpdate = new JButton("update your minecraft");

    private JLabel labelKanna;
    private JLabel labelCircleOne;
    private JLabel labelCircleTwo;
    private JLabel labelCircleThree;
    private JLabel labelCircleFour;
    private JLabel labelCircleFive;

    private JLabel labelStepOne = new JLabel(Main.applyWhite("backup or remove"));
    private JLabel labelStepTwo = new JLabel(Main.applyWhite("install forge and java"));
    private JLabel labelStepThree = new JLabel(Main.applyWhite("create launch profile"));
    private JLabel labelStepFour = new JLabel(Main.applyWhite("transfer core files"));
    private JLabel labelStepFive = new JLabel(Main.applyWhite("install optional files"));
    private JLabel labelHeader = new JLabel(Main.lukaRainbowfy("KannaCraft 3.0 | Mods At Work | luka#8375"));
    public static JLabel labelFooter = new JLabel(Main.lukaRainbowfy("\"how else are we to determine a moment of love?\""));
    private JLabel labelDivider = new JLabel(Main.applyWhite(divider+divider+divider));
    private JLabel labelCredit = new JLabel(Main.applyWhite("kanna artwork by ongyageum, circles by yuma"));

    private JCheckBox cbComments = new JCheckBox(Main.applyWhite("test checkbox"));

    private Color backgroundColor = new Color(44,47,51);



    public Window(){
        setTitle("luka#8375 mods at work!");
        setSize(400,600);
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

        labelKanna = new JLabel(new ImageIcon(this.getClass().getResource("/kanna_cutout.png")));
        labelKanna.setBounds(0, 10, 400,  200);
        labelKanna.setHorizontalAlignment(SwingConstants.CENTER);

        labelHeader.setBounds(0, 10, 400, 20);
        labelHeader.setHorizontalAlignment(SwingConstants.CENTER);
        labelDivider.setBounds(0, 30, 400, 20);
        labelDivider.setHorizontalAlignment(SwingConstants.CENTER);

        labelCircleOne = new JLabel(new ImageIcon(this.getClass().getResource("/lookaOne.png")));
        labelCircleOne.setBounds(15, 110, 200,  200);
        labelStepOne.setBounds(145, 110, 400,  200);

        labelCircleTwo = new JLabel(new ImageIcon(this.getClass().getResource("/lookaTwo.png")));
        labelCircleTwo.setBounds(15, 160, 200,  200);
        labelStepTwo.setBounds(145, 160, 400,  200);

        labelCircleThree = new JLabel(new ImageIcon(this.getClass().getResource("/lookaThree.png")));
        labelCircleThree.setBounds(15, 210, 200,  200);
        labelStepThree.setBounds(145, 210, 400,  200);

        labelCircleFour = new JLabel(new ImageIcon(this.getClass().getResource("/lookaFour.png")));
        labelCircleFour.setBounds(15, 260, 200,  200);
        labelStepFour.setBounds(145, 260, 400,  200);

        labelCircleFive = new JLabel(new ImageIcon(this.getClass().getResource("/lookaFive.png")));
        labelCircleFive.setBounds(15, 310, 200,  200);
        labelStepFive.setBounds(145, 310, 400,  200);

        labelCredit.setBounds(0, 350, 400,  200);
        labelCredit.setFont (labelCredit.getFont ().deriveFont(10.0f));
        labelCredit.setHorizontalAlignment(SwingConstants.CENTER);

        cbComments.setBounds(10,90,175,20);
        cbComments.setBackground(backgroundColor);

        btnApply.setBounds(25, 465, 350, 20);
        btnApply.setHorizontalAlignment(SwingConstants.CENTER);
        btnUpdate.setBounds(25, 490, 350, 20);
        btnUpdate.setHorizontalAlignment(SwingConstants.CENTER);

        labelFooter.setBounds(0, 520, 380, 20);
        labelFooter.setHorizontalAlignment(SwingConstants.CENTER);


        add(labelHeader);
        add(labelDivider);
        add(labelKanna);
        add(labelCircleOne);
        add(labelStepOne);
        add(labelCircleTwo);
        add(labelStepTwo);
        add(labelCircleThree);
        add(labelStepThree);
        add(labelCircleFour);
        add(labelStepFour);
        add(labelCircleFive);
        add(labelStepFive);
        add(labelCredit);
        add(btnApply);
        add(btnUpdate);
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
                Main.startProcess();
                Main.mainFrame.setVisible(false);
            }
        });

        btnUpdate.addActionListener(new ActionListener() {
            @Override
            public void actionPerformed(ActionEvent e) {
                Main.updatePack();
            }
        });


    }
}
