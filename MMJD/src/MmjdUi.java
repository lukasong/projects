import com.formdev.flatlaf.FlatDarculaLaf;
import javax.swing.*;
import java.awt.*;

public class MmjdUi extends JFrame {

    private JTextField oldUsernameField, newUsernameField;
    private JButton changeUsernameButton;

    public MmjdUi() {

        // establish jframe
        super("Moshi Moshi Jesus Desu!?");
        setSize(400, 200);
        setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        setLocationRelativeTo(null);
        // get hansel.png from resources and set it as the icon
        ImageIcon icon = new ImageIcon(getClass().getResource("Hansel.png"));
        setIconImage(icon.getImage());

        // use flatlaf
        try {
            UIManager.setLookAndFeel(new FlatDarculaLaf());
        } catch (Exception ex) {
            System.err.println("Failed to initialize UI");
        }

        // create labels + text boxes + buttons
        JLabel oldUsernameLabel = new JLabel("Mochi Dir:");
        JLabel newUsernameLabel = new JLabel("Config File:");
        oldUsernameField = new JTextField(20);
        newUsernameField = new JTextField(20);
        changeUsernameButton = new JButton("Update Moshers");
        changeUsernameButton.addActionListener(e -> changeUsername());

        // create the panel and add the components to it
        JPanel panel = new JPanel();
        GroupLayout layout = new GroupLayout(panel);
        panel.setLayout(layout);
        layout.setAutoCreateGaps(true);
        layout.setAutoCreateContainerGaps(true);
        layout.setHorizontalGroup(
                layout.createParallelGroup(GroupLayout.Alignment.LEADING)
                        .addGroup(layout.createSequentialGroup()
                                .addGroup(layout.createParallelGroup(GroupLayout.Alignment.LEADING)
                                        .addComponent(oldUsernameLabel)
                                        .addComponent(newUsernameLabel))
                                .addGroup(layout.createParallelGroup(GroupLayout.Alignment.LEADING)
                                        .addComponent(oldUsernameField)
                                        .addComponent(newUsernameField)))
                        .addComponent(changeUsernameButton, GroupLayout.Alignment.TRAILING)
        );
        layout.setVerticalGroup(
                layout.createSequentialGroup()
                        .addGroup(layout.createParallelGroup(GroupLayout.Alignment.BASELINE)
                                .addComponent(oldUsernameLabel)
                                .addComponent(oldUsernameField))
                        .addGroup(layout.createParallelGroup(GroupLayout.Alignment.BASELINE)
                                .addComponent(newUsernameLabel)
                                .addComponent(newUsernameField))
                        .addComponent(changeUsernameButton)
        );
        add(panel);

        // display the frame
        setVisible(true);
    }

    private void changeUsername() {
        // this is the method that is called when the button is hit
        String oldUsername = oldUsernameField.getText();
        String newUsername = newUsernameField.getText();
        System.out.println("Changing username from " + oldUsername + " to " + newUsername);
    }

}