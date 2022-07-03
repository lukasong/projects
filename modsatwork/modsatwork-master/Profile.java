package me.lukasong.maw;

import javax.swing.*;
import java.awt.*;
import java.awt.event.*;
import java.io.File;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

class Profile extends JFrame {

    private String divider = "--------------------------";
    private String[] iconNames =
            { "Water", "Pumpkin", "Chest", "Enchanting_Table", "Crafting_Table", "Furnace", "Furnace_On", "Ice_Packed",
            "TNT", "Bookshelf", "Lectern_Book", "Redstone_Block", "Cake", "Soul_Sand", "Bedrock", "Quartz_Ore", "Snow",
            "Obsidian", "Diamond_Block", "Emerald_Block", "Netherrack", "Creeper_Head", "Skeleton_Head", "Sandstone"};
    private String[] ramLimits =
            { "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31", "32" };

    private JButton btnApply = new JButton("create minecraft profile");

    private JLabel labelCircleThree;

    private JLabel labelHeader = new JLabel(Main.lukaRainbowfy("create minecraft client profile"));
    private JLabel labelFooter = new JLabel(Window.labelFooter.getText());
    private JLabel labelDivider = new JLabel(Main.applyWhite(divider+divider+divider));
    private JLabel labelName = new JLabel(Main.applyWhite("profile name:"));
    private JLabel labelMin = new JLabel(Main.applyWhite("minimum ram:"));
    private JLabel labelMax = new JLabel(Main.applyWhite("maximum ram:"));
    private JLabel labelIcon = new JLabel(Main.applyWhite("icon:"));
    private JLabel labelDetected = new JLabel(Main.applyWhite("the correct forge installation was detected and selected :)"));

    private JTextField tfName = new JTextField();
    private JTextField tfMin = new JTextField();
    private JTextField tfMax = new JTextField();
    private JTextField tfIcon = new JTextField();

    private JComboBox blockList = new JComboBox(iconNames);
    private JComboBox minRamList = new JComboBox(ramLimits);
    private JComboBox maxRamList = new JComboBox(ramLimits);

    private Color backgroundColor = new Color(44,47,51);



    public Profile(){
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

        Path testDirectory = Paths.get(Main.getLibrary() + File.separator + "versions" + File.separator + "1.12.2-forge1.12.2-14.23.5.2838");
        if(!Files.exists(testDirectory)){
            labelDetected = new JLabel(Main.applyWhite("forge was not detected! please restart the installer and reinstall..."));
        }

        tfName.setText("KannaCraft 3");
        minRamList.setSelectedIndex(3);
        maxRamList.setSelectedIndex(9);

        labelCircleThree = new JLabel(new ImageIcon(this.getClass().getResource("/lookaThree.png")));
        labelCircleThree.setBounds(110, 0, 200,  50);
        labelHeader.setBounds(20, 15, 600, 20);
        labelHeader.setHorizontalAlignment(SwingConstants.CENTER);
        labelDivider.setBounds(0, 40, 600, 20);
        labelDivider.setHorizontalAlignment(SwingConstants.CENTER);

        labelName.setBounds(0, 70, 400, 20);
        labelName.setHorizontalAlignment(SwingConstants.CENTER);
        tfName.setBounds(250, 70, 200, 20);
        labelMin.setBounds(0, 95, 400, 20);
        labelMin.setHorizontalAlignment(SwingConstants.CENTER);
        minRamList.setBounds(250, 95, 200, 20);
        labelMax.setBounds(0, 120, 400, 20);
        labelMax.setHorizontalAlignment(SwingConstants.CENTER);
        maxRamList.setBounds(250, 120, 200, 20);
        labelIcon.setBounds(0, 145, 400, 20);
        labelIcon.setHorizontalAlignment(SwingConstants.CENTER);
        blockList.setBounds(250, 145, 200, 20);

        labelDetected.setBounds(0, 170, 600, 20);
        labelDetected.setHorizontalAlignment(SwingConstants.CENTER);

        btnApply.setBounds(25, 300, 550, 20);
        btnApply.setHorizontalAlignment(SwingConstants.CENTER);

        labelFooter.setBounds(0, 340, 600, 20);
        labelFooter.setHorizontalAlignment(SwingConstants.CENTER);


        add(labelCircleThree);
        add(labelHeader);
        add(labelDivider);
        add(labelName);
        add(tfName);
        add(labelMin);
        add(minRamList);
        add(labelMax);
        add(maxRamList);
        add(labelIcon);
        add(blockList);
        add(labelDetected);
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
                Main.stepThree(tfName.getText(), minRamList.getSelectedItem().toString(), maxRamList.getSelectedItem().toString(), blockList.getSelectedItem().toString());
            }
        });


    }
}
