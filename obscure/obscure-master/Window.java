package me.lukasong.shaderobsf;

import javax.swing.*;
import java.awt.*;
import java.awt.event.*;

class Window extends JFrame {

    public static JButton btnApply = new JButton("lets go");
    public static JButton btnSettings = new JButton("save state as default");
    public static JButton btnDirectories = new JButton("set directories");

    public static JTextField tfCommentLength = new JTextField();
    public static JTextField tfCommentAmount = new JTextField();
    public static JTextField tfGrabpasses = new JTextField();
    public static JTextField tfTermsOne = new JTextField();
    public static JTextField tfTermsTwo = new JTextField();
    public static JTextField tfAuthor = new JTextField();
    public static JTextField tfBuyer = new JTextField();

    private JLabel labelHeader = new JLabel(Main.lukaRainbowfy("luka#8375 shader obfuscation"));
    private JLabel labelFooter = new JLabel(Main.lukaRainbowfy("they tryna be carti"));
    private JLabel labelDivider = new JLabel(Main.applyWhite("---------------------------------"));
    private JLabel labelCommentLength = new JLabel(Main.applyWhite("Max Length:"));
    private JLabel labelCommentAmount = new JLabel(Main.applyWhite("Freq.:"));
    private JLabel labelDividerComment = new JLabel(Main.applyWhite("---------------------------------"));
    private JLabel labelGrabpass = new JLabel(Main.applyWhite("Grabpasses:"));
    private JLabel labelGrabpassInstructions = new JLabel(Main.applyWhite("[use commas to seperate terms]"));
    private JLabel labelDividerGrabpass = new JLabel(Main.applyWhite("---------------------------------"));
    private JLabel labelTermsOne = new JLabel(Main.applyWhite("Terms:"));
    private JLabel labelTermsTwo = new JLabel(Main.applyWhite("Replace With:"));
    private JLabel labelDividerTerms = new JLabel(Main.applyWhite("---------------------------------"));
    private JLabel labelDividerUUID = new JLabel(Main.applyWhite("---------------------------------"));
    private JLabel labelAuthor = new JLabel(Main.applyWhite("Author:"));
    private JLabel labelBuyer = new JLabel(Main.applyWhite("Buyer"));

    public static JCheckBox cbComments = new JCheckBox(Main.applyWhite("Add Random Comments?"));
    public static JCheckBox cbCommentsAvoid = new JCheckBox(Main.applyWhite("Avoid Comments?"));
    public static JCheckBox cbGrabpass = new JCheckBox(Main.applyWhite("Allow Grabpass Replacement?"));
    public static JCheckBox cbTerms = new JCheckBox(Main.applyWhite("Replace Terms?"));
    public static JCheckBox cbRandomTerms = new JCheckBox(Main.applyWhite("Randomize Replacements?"));
    public static JCheckBox cbUUID = new JCheckBox(Main.applyWhite("Generate UUID?"));
    public static JCheckBox cbFakeUUID = new JCheckBox(Main.applyWhite("Fake UUID?"));
    public static JCheckBox cbZip = new JCheckBox(Main.applyWhite("Zip Files?"));
    public static JCheckBox cbWatermark = new JCheckBox(Main.applyWhite("Watermark?"));

    public static Directory directWindow;
    public static Color backgroundColor = new Color(44,47,51);



    public Window(){
        setTitle("luka#8375 shader obfuscator");
        setSize(400,680);
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


        labelHeader.setBounds(0, 10, 400, 20);
        labelHeader.setHorizontalAlignment(SwingConstants.CENTER);
        labelGrabpassInstructions.setBounds(0, 35, 400, 20);
        labelGrabpassInstructions.setHorizontalAlignment(SwingConstants.CENTER);
        labelDivider.setBounds(0, 60, 400, 20);
        labelDivider.setHorizontalAlignment(SwingConstants.CENTER);

        cbComments.setBounds(10,90,175,20);
        cbComments.setBackground(backgroundColor);
        cbCommentsAvoid.setBounds(200, 90, 200, 20);
        cbCommentsAvoid.setBackground(backgroundColor);
        labelCommentLength.setBounds(20, 120, 100, 20);
        tfCommentLength.setBounds(120,120, 50, 20);
        labelCommentAmount.setBounds(190, 120, 70, 20);
        tfCommentAmount.setBounds(230, 120, 50, 20);
        labelDividerComment.setBounds(0, 150, 400, 20);
        labelDividerComment.setHorizontalAlignment(SwingConstants.CENTER);

        cbGrabpass.setBounds(10, 180,400, 20);
        cbGrabpass.setBackground(backgroundColor);
        labelGrabpass.setBounds(10, 210, 80, 20);
        tfGrabpasses.setBounds(90, 210, 300, 20);
        labelDividerGrabpass.setBounds(0, 240, 400, 20);
        labelDividerGrabpass.setHorizontalAlignment(SwingConstants.CENTER);

        cbTerms.setBounds(10, 270, 150, 20);
        cbTerms.setBackground(backgroundColor);
        cbRandomTerms.setBounds(170, 270, 200, 20);
        cbRandomTerms.setBackground(backgroundColor);
        labelTermsOne.setBounds(20, 300, 70, 20);
        tfTermsOne.setBounds(100, 300, 250, 20);
        labelTermsTwo.setBounds(20, 330, 100, 20);
        tfTermsTwo.setBounds(115, 330, 235, 20);
        labelDividerTerms.setBounds(0, 360, 400, 20);
        labelDividerTerms.setHorizontalAlignment(SwingConstants.CENTER);

        cbUUID.setBounds(10, 390, 150, 20);
        cbUUID.setBackground(backgroundColor);
        cbFakeUUID.setBounds(170, 390, 120, 20);
        cbFakeUUID.setBackground(backgroundColor);
        labelDividerUUID.setBounds(0, 420, 400, 20);
        labelDividerUUID.setHorizontalAlignment(SwingConstants.CENTER);

        btnDirectories.setBounds(25, 450, 350, 20);
        btnDirectories.setHorizontalAlignment(SwingConstants.CENTER);

        cbZip.setBounds(50, 480, 150, 20);
        cbZip.setBackground(backgroundColor);
        cbWatermark.setBounds(220, 480, 100, 20);
        cbWatermark.setBackground(backgroundColor);

        labelAuthor.setBounds(20, 510, 70, 20);
        tfAuthor.setBounds(70, 510, 120, 20);
        labelBuyer.setBounds(210, 510, 60, 20);
        tfBuyer.setBounds(250, 510, 120, 20);

        btnSettings.setBounds(25, 540, 350, 20);
        btnSettings.setHorizontalAlignment(SwingConstants.CENTER);

        btnApply.setBounds(25, 570, 350, 20);
        btnApply.setHorizontalAlignment(SwingConstants.CENTER);

        labelFooter.setBounds(0, 600, 400, 20);
        labelFooter.setHorizontalAlignment(SwingConstants.CENTER);



        add(labelHeader);
        add(labelDivider);
        add(cbComments);
        add(cbCommentsAvoid);
        add(labelCommentLength);
        add(tfCommentLength);
        add(labelCommentAmount);
        add(tfCommentAmount);
        add(labelDividerComment);
        add(cbGrabpass);
        add(labelGrabpass);
        add(tfGrabpasses);
        add(labelGrabpassInstructions);
        add(labelDividerGrabpass);
        add(cbTerms);
        add(cbRandomTerms);
        add(tfTermsOne);
        add(labelTermsOne);
        add(tfTermsTwo);
        add(labelTermsTwo);
        add(labelDividerTerms);
        add(cbUUID);
        add(cbFakeUUID);
        add(labelDividerUUID);
        add(btnDirectories);
        add(cbZip);
        add(cbWatermark);
        add(labelAuthor);
        add(tfAuthor);
        add(labelBuyer);
        add(tfBuyer);
        add(btnSettings);
        add(btnApply);
        add(labelFooter);

    }

    private void initEvent(){

        this.addWindowListener(new WindowAdapter() {
            public void windowClosing(WindowEvent e){
                System.exit(1);
            }
        });

        btnDirectories.addActionListener(new ActionListener() {
            @Override
            public void actionPerformed(ActionEvent e) {
                directWindow = new Directory();
                directWindow.setVisible(true);
            }
        });

        btnSettings.addActionListener(new ActionListener() {
            @Override
            public void actionPerformed(ActionEvent e) {
                Settings.ApplySettings(
                        cbComments.isSelected(),
                        tfCommentLength.getText(),
                        tfCommentAmount.getText(),
                        cbGrabpass.isSelected(),
                        tfGrabpasses.getText(),
                        cbTerms.isSelected(),
                        cbRandomTerms.isSelected(),
                        tfTermsOne.getText(),
                        tfTermsTwo.getText(),
                        cbUUID.isSelected(),
                        cbFakeUUID.isSelected(),
                        cbZip.isSelected(),
                        cbWatermark.isSelected(),
                        tfAuthor.getText(),
                        tfBuyer.getText(),
                        Directory.tfShader.getText(),
                        Directory.tfShaderTwo.getText(),
                        Directory.tfShaderThree.getText(),
                        Directory.tfCGOne.getText(),
                        Directory.tfCGTwo.getText(),
                        Directory.tfCGThree.getText(),
                        Directory.tfEditor.getText(),
                        Directory.tfResource.getText(),
                        Directory.tfOutput.getText(),
                        Directory.tfLog.getText(),
                        Directory.tfName.getText(),
                        Directory.tfMain.getText(),
                        cbCommentsAvoid.isSelected()
                );
            }
        });

        btnApply.addActionListener(new ActionListener() {
            @Override
            public void actionPerformed(ActionEvent e) {
                Main.applyObfuscation();
            }
        });


    }
}
