package me.lukasong.shaderobsf;

import sun.misc.JavaLangAccess;

import javax.swing.*;
import javax.swing.filechooser.FileNameExtensionFilter;
import java.awt.*;
import java.awt.event.*;

class Directory extends JFrame {

    private JButton btnApply = new JButton("apply directories");
    private JButton btnSettings = new JButton("set as default directories");
    private JButton btnShaderOne = new JButton("...");
    private JButton btnShaderTwo = new JButton("...");
    private JButton btnShaderThree = new JButton("...");
    private JButton btnCGOne = new JButton("...");
    private JButton btnCGTwo = new JButton("...");
    private JButton btnCGThree = new JButton("...");
    private JButton btnEditor = new JButton("...");
    private JButton btnResource = new JButton("...");
    private JButton btnOutput = new JButton("...");
    private JButton btnLog = new JButton("...");
    private JButton btnMain = new JButton("...");

    public static JTextField tfShader = new JTextField();
    public static JTextField tfShaderTwo = new JTextField();
    public static JTextField tfShaderThree = new JTextField();
    public static JTextField tfCGOne = new JTextField();
    public static JTextField tfCGTwo = new JTextField();
    public static JTextField tfCGThree = new JTextField();
    public static JTextField tfEditor = new JTextField();
    public static JTextField tfResource = new JTextField();
    public static JTextField tfOutput = new JTextField();
    public static JTextField tfLog = new JTextField();
    public static JTextField tfName = new JTextField();
    public static JTextField tfMain = new JTextField();

    private JLabel labelHeader = new JLabel(Main.lukaRainbowfy("the directories"));
    private JLabel labelFooter = new JLabel(Main.lukaRainbowfy("they tryna be carti"));
    private JLabel labelInfo = new JLabel(Main.applyWhite("[leave stuff not needed blank]"));
    private JLabel labelDivider = new JLabel(Main.applyWhite("---------------------------------"));
    private JLabel labelShader = new JLabel(Main.applyWhite("Shader:"));
    private JLabel labelShaderTwo = new JLabel(Main.applyWhite("Shader:"));
    private JLabel labelShaderThree = new JLabel(Main.applyWhite("Shader:"));
    private JLabel labelCGOne = new JLabel(Main.applyWhite("CGInc:"));
    private JLabel labelCGTwo = new JLabel(Main.applyWhite("CGInc:"));
    private JLabel labelCGThree = new JLabel(Main.applyWhite("CGInc:"));
    private JLabel labelEditor = new JLabel(Main.applyWhite("Editor:"));
    private JLabel labelResource = new JLabel(Main.applyWhite("Resource:"));
    private JLabel labelOutput = new JLabel(Main.applyWhite("Output:"));
    private JLabel labelLog = new JLabel(Main.applyWhite("Log:"));
    private JLabel labelName = new JLabel(Main.applyWhite("Shader Name:"));
    private JLabel labelMain = new JLabel(Main.applyWhite("Main Folder:"));


    private JCheckBox cbComments = new JCheckBox(Main.applyWhite("Add Random Comments?"));




    public Directory(){
        setTitle("luka#8375 shader obfuscator");
        setSize(400,535);
        Dimension dim = Toolkit.getDefaultToolkit().getScreenSize();
        setLocation(dim.width/2-this.getSize().width/2, dim.height/2-this.getSize().height/2);
        setLayout(null);
        setResizable(false);
        setBackground(Color.BLACK);
        getContentPane().setBackground(new Color(44,47,51));
        setDefaultCloseOperation(JFrame.DISPOSE_ON_CLOSE);
        repaint();
        initComponent();
        initEvent();
    }

    private void initComponent(){


        labelHeader.setBounds(0, 10, 400, 20);
        labelHeader.setHorizontalAlignment(SwingConstants.CENTER);
        labelInfo.setBounds(0, 30, 400, 20);
        labelInfo.setHorizontalAlignment(SwingConstants.CENTER);
        labelDivider.setBounds(0, 65, 400, 20);
        labelDivider.setHorizontalAlignment(SwingConstants.CENTER);

        labelMain.setBounds(20, 95, 100, 20);
        tfMain.setBounds(100, 95, 260, 20);
        btnMain.setBounds(360, 95, 20, 20);

        labelShader.setBounds(20, 125, 100, 20);
        tfShader.setBounds(80, 125, 280, 20);
        btnShaderOne.setBounds(360, 125, 20, 20);

        labelShaderTwo.setBounds(20, 155, 100, 20);
        tfShaderTwo.setBounds(80, 155, 280, 20);
        btnShaderTwo.setBounds(360, 155, 20, 20);

        labelShaderThree.setBounds(20, 185, 100, 20);
        tfShaderThree.setBounds(80, 185, 280, 20);
        btnShaderThree.setBounds(360, 185, 20, 20);

        labelCGOne.setBounds(20, 215, 100, 20);
        tfCGOne.setBounds(80, 215, 280, 20);
        btnCGOne.setBounds(360, 215, 20, 20);

        labelCGTwo.setBounds(20, 245, 100, 20);
        tfCGTwo.setBounds(80, 245, 280, 20);
        btnCGTwo.setBounds(360, 245, 20, 20);

        labelCGThree.setBounds(20, 275, 100, 20);
        tfCGThree.setBounds(80, 275, 280, 20);
        btnCGThree.setBounds(360, 275, 20, 20);

        labelEditor.setBounds(20, 305, 100, 20);
        tfEditor.setBounds(80, 305, 280, 20);
        btnEditor.setBounds(360, 305, 20, 20);

        labelResource.setBounds(20, 335, 100, 20);
        tfResource.setBounds(80, 335, 280, 20);
        btnResource.setBounds(360, 335, 20, 20);

        labelOutput.setBounds(20, 365, 100, 20);
        tfOutput.setBounds(80, 365, 280, 20);
        btnOutput.setBounds(360, 365, 20, 20);

        labelLog.setBounds(20, 395, 100, 20);
        tfLog.setBounds(80, 395, 280, 20);
        btnLog.setBounds(360, 395, 20, 20);

        //btnSettings.setBounds(25, 395, 350, 20);
        //btnSettings.setHorizontalAlignment(SwingConstants.CENTER);
        
        labelName.setBounds(20, 425, 100, 20);
        tfName.setBounds(110, 425, 272, 20);

        btnApply.setBounds(25, 455, 350, 20);
        btnApply.setHorizontalAlignment(SwingConstants.CENTER);

        labelFooter.setBounds(0, 485, 400, 20);
        labelFooter.setHorizontalAlignment(SwingConstants.CENTER);


        add(labelHeader);
        add(labelInfo);
        add(labelDivider);
        add(labelShader);
        add(tfShader);
        add(labelShaderTwo);
        add(tfShaderTwo);
        add(labelShaderThree);
        add(tfShaderThree);
        add(labelCGOne);
        add(tfCGOne);
        add(labelCGTwo);
        add(tfCGTwo);
        add(labelCGThree);
        add(tfCGThree);
        add(labelEditor);
        add(tfEditor);
        add(labelResource);
        add(tfResource);
        add(labelOutput);
        add(tfOutput);
        add(labelLog);
        add(tfLog);
        add(btnSettings);
        add(btnApply);
        add(btnShaderOne);
        add(btnShaderTwo);
        add(btnShaderThree);
        add(btnCGOne);
        add(btnCGTwo);
        add(btnCGThree);
        add(btnEditor);
        add(btnResource);
        add(btnOutput);
        add(btnLog);
        add(labelName);
        add(tfName);
        add(labelMain);
        add(tfMain);
        add(btnMain);

        add(labelFooter);




    }

    private void initEvent(){

        btnApply.addActionListener(new ActionListener() {
            @Override
            public void actionPerformed(ActionEvent e) {
                Window.directWindow.dispose();
            }
        });

        btnShaderOne.addActionListener(new ActionListener() {
            @Override
            public void actionPerformed(ActionEvent e) {
                JFileChooser pickFile = new JFileChooser();
                pickFile.setFileSelectionMode(JFileChooser.FILES_ONLY);
                FileNameExtensionFilter fileFilter = new FileNameExtensionFilter
                        ("shaders", "shader");
                pickFile.setFileFilter(fileFilter);
                int action = pickFile.showOpenDialog(null);
                if(action == JFileChooser.APPROVE_OPTION) {
                    tfShader.setText(pickFile.getSelectedFile().getAbsolutePath());
                }
            }
        });

        btnShaderTwo.addActionListener(new ActionListener() {
            @Override
            public void actionPerformed(ActionEvent e) {
                JFileChooser pickFile = new JFileChooser();
                pickFile.setFileSelectionMode(JFileChooser.FILES_ONLY);
                FileNameExtensionFilter fileFilter = new FileNameExtensionFilter
                        ("shaders", "shader");
                pickFile.setFileFilter(fileFilter);
                int action = pickFile.showOpenDialog(null);
                if(action == JFileChooser.APPROVE_OPTION) {
                    tfShaderTwo.setText(pickFile.getSelectedFile().getAbsolutePath());
                }
            }
        });

        btnShaderThree.addActionListener(new ActionListener() {
            @Override
            public void actionPerformed(ActionEvent e) {
                JFileChooser pickFile = new JFileChooser();
                pickFile.setFileSelectionMode(JFileChooser.FILES_ONLY);
                FileNameExtensionFilter fileFilter = new FileNameExtensionFilter
                        ("shaders", "shader");
                pickFile.setFileFilter(fileFilter);
                int action = pickFile.showOpenDialog(null);
                if(action == JFileChooser.APPROVE_OPTION) {
                    tfShaderThree.setText(pickFile.getSelectedFile().getAbsolutePath());
                }
            }
        });

        btnCGOne.addActionListener(new ActionListener() {
            @Override
            public void actionPerformed(ActionEvent e) {
                JFileChooser pickFile = new JFileChooser();
                pickFile.setFileSelectionMode(JFileChooser.FILES_ONLY);
                FileNameExtensionFilter fileFilter = new FileNameExtensionFilter
                        ("cgincludes", "cginc");
                pickFile.setFileFilter(fileFilter);
                int action = pickFile.showOpenDialog(null);
                if(action == JFileChooser.APPROVE_OPTION) {
                    tfCGOne.setText(pickFile.getSelectedFile().getAbsolutePath());
                }
            }
        });

        btnCGTwo.addActionListener(new ActionListener() {
            @Override
            public void actionPerformed(ActionEvent e) {
                JFileChooser pickFile = new JFileChooser();
                pickFile.setFileSelectionMode(JFileChooser.FILES_ONLY);
                FileNameExtensionFilter fileFilter = new FileNameExtensionFilter
                        ("cgincludes", "cginc");
                pickFile.setFileFilter(fileFilter);
                int action = pickFile.showOpenDialog(null);
                if(action == JFileChooser.APPROVE_OPTION) {
                    tfCGTwo.setText(pickFile.getSelectedFile().getAbsolutePath());
                }
            }
        });

        btnCGThree.addActionListener(new ActionListener() {
            @Override
            public void actionPerformed(ActionEvent e) {
                JFileChooser pickFile = new JFileChooser();
                pickFile.setFileSelectionMode(JFileChooser.FILES_ONLY);
                FileNameExtensionFilter fileFilter = new FileNameExtensionFilter
                        ("cgincludes", "cginc");
                pickFile.setFileFilter(fileFilter);
                int action = pickFile.showOpenDialog(null);
                if(action == JFileChooser.APPROVE_OPTION) {
                    tfCGThree.setText(pickFile.getSelectedFile().getAbsolutePath());
                }
            }
        });

        btnEditor.addActionListener(new ActionListener() {
            @Override
            public void actionPerformed(ActionEvent e) {
                JFileChooser pickFile = new JFileChooser();
                pickFile.setFileSelectionMode(JFileChooser.FILES_ONLY);
                FileNameExtensionFilter fileFilter = new FileNameExtensionFilter
                        ("shader editor", "cs");
                pickFile.setFileFilter(fileFilter);
                int action = pickFile.showOpenDialog(null);
                if(action == JFileChooser.APPROVE_OPTION) {
                    tfEditor.setText(pickFile.getSelectedFile().getAbsolutePath());
                }
            }
        });

        btnResource.addActionListener(new ActionListener() {
            @Override
            public void actionPerformed(ActionEvent e) {
                JFileChooser pickFile = new JFileChooser();
                pickFile.setFileSelectionMode(JFileChooser.DIRECTORIES_ONLY);
                FileNameExtensionFilter fileFilter = new FileNameExtensionFilter
                        ("your resources folder", "directory");
                pickFile.setFileFilter(fileFilter);
                int action = pickFile.showOpenDialog(null);
                if(action == JFileChooser.APPROVE_OPTION) {
                    tfResource.setText(pickFile.getSelectedFile().getAbsolutePath());
                }
            }
        });

        btnOutput.addActionListener(new ActionListener() {
            @Override
            public void actionPerformed(ActionEvent e) {
                JFileChooser pickFile = new JFileChooser();
                pickFile.setFileSelectionMode(JFileChooser.DIRECTORIES_ONLY);
                FileNameExtensionFilter fileFilter = new FileNameExtensionFilter
                        ("master output folder", "directory");
                pickFile.setFileFilter(fileFilter);
                int action = pickFile.showOpenDialog(null);
                if(action == JFileChooser.APPROVE_OPTION) {
                    tfOutput.setText(pickFile.getSelectedFile().getAbsolutePath());
                }
            }
        });

        btnLog.addActionListener(new ActionListener() {
            @Override
            public void actionPerformed(ActionEvent e) {
                JFileChooser pickFile = new JFileChooser();
                pickFile.setFileSelectionMode(JFileChooser.DIRECTORIES_ONLY);
                FileNameExtensionFilter fileFilter = new FileNameExtensionFilter
                        ("folder where log is", "directory");
                pickFile.setFileFilter(fileFilter);
                int action = pickFile.showOpenDialog(null);
                if(action == JFileChooser.APPROVE_OPTION) {
                    tfLog.setText(pickFile.getSelectedFile().getAbsolutePath());
                }
            }
        });

        btnMain.addActionListener(new ActionListener() {
            @Override
            public void actionPerformed(ActionEvent e) {
                JFileChooser pickFile = new JFileChooser();
                pickFile.setFileSelectionMode(JFileChooser.DIRECTORIES_ONLY);
                FileNameExtensionFilter fileFilter = new FileNameExtensionFilter
                        ("main folder", "directory");
                pickFile.setFileFilter(fileFilter);
                int action = pickFile.showOpenDialog(null);
                if(action == JFileChooser.APPROVE_OPTION) {
                    tfMain.setText(pickFile.getSelectedFile().getAbsolutePath());
                }
            }
        });

    }

}
