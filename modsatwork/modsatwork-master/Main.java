package me.lukasong.maw;

import javax.swing.*;
import java.awt.*;
import java.io.*;
import java.net.URI;
import java.net.URISyntaxException;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;
import java.nio.file.StandardCopyOption;
import java.util.ArrayList;
import java.util.UUID;
import java.util.concurrent.TimeUnit;

public class Main {

    /* global variables */
    public static String modpack;
    public static Window mainFrame;
    public static Backup firstFrame;
    public static Forge secondFrame;
    public static Profile thirdFrame;
    public static Core fourthFrame;
    public static Optional fifthFrame;
    public static Done endFrame;

    /* main method */
    public static void main(String[] args) {
        modpack = "Kannacraft3";
        mainFrame = new Window();
        mainFrame.setVisible(true);
        mainFrame.setDefaultCloseOperation(JFrame.DISPOSE_ON_CLOSE);
    }



    /* helper methods */
    public static void lukaLog(int logType, String logMessage) {
        //just formatted logging
        String lukaTag = "[luka mods at work!]";
        switch(logType) {
            case 0:
                System.out.println(lukaTag + "[info] " + logMessage);
                break;
            case 1:
                System.out.println(lukaTag + "[error] " + logMessage);
                break;
            case 2:
                System.out.println(lukaTag + "[update] " + logMessage);
                break;
        }
    }

    public static String lukaRainbowfy(String messageToRainbowfy){
        int stringLength = messageToRainbowfy.length();
        String rainbowRebuild = "";
        int currentROYGBIVslot = 0;
        for(int i = 0; i < stringLength; i++)
        {
            currentROYGBIVslot++;
            if (currentROYGBIVslot > 7) currentROYGBIVslot = 1;
            String currentLetter = String.valueOf(messageToRainbowfy.charAt(i));
            if (currentLetter.equals(" ")) currentROYGBIVslot--;
            String currentColour = "";
            switch (currentROYGBIVslot)
            {
                case 1:
                    currentColour = "<font color='red'>";
                    break;
                case 2:
                    currentColour = "<font color='orange'>";
                    break;
                case 3:
                    currentColour = "<font color='yellow'>";
                    break;
                case 4:
                    currentColour = "<font color='green'>";
                    break;
                case 5:
                    currentColour = "<font color='rgb(18,167,219)'>";
                    break;
                case 6:
                    currentColour = "<font color='rgb(174,45,254)'>";
                    break;
                case 7:
                    currentColour = "<font color='rgb(176,5,145)'>";
                    break;
                default:
                    currentColour = "<font color='red'>";
                    break;
            }
            currentLetter = currentColour + currentLetter + "</font>";
            rainbowRebuild += currentLetter;
        }
        rainbowRebuild = "<html>" + rainbowRebuild + "</html>";
        return rainbowRebuild;
    }

    public static String applyWhite(String messageToColor){
        return "<html><font color='white'>" + messageToColor + "</font></html>";
    }

    public static void makeDirectory(String pathToMake){
        //unused
        Path settingsPath = Paths.get(pathToMake);
        if(!Files.exists(settingsPath)) new File(settingsPath.toString()).mkdirs();
    }

    public static void showError(String errorMessage){
        JOptionPane.showMessageDialog(null, errorMessage, "luka#8375 shader obfuscator",JOptionPane.INFORMATION_MESSAGE);
    }

    public static String getLibrary(){
        String operatingSystem = System.getProperty("os.name").toLowerCase();
        boolean systemWindows = operatingSystem.contains("window");
        boolean systemMac = operatingSystem.contains("mac");
        String path = null;
        if(systemWindows){
            path = System.getenv("APPDATA") + File.separator + ".minecraft";
        }else if(systemMac){
            path =  System.getProperty("user.home") + File.separator + "Library" + File.separator + "Application Support" + File.separator + ".minecraft";
        }
        Path settingsPath = Paths.get(path);
        if(!Files.exists(settingsPath)) new File(settingsPath.toString()).mkdirs();
        return path;
    }

    public static String getJavaType(){
        return System.getProperty("sun.arch.data.model");
    }

    public static URI newLink(String thisURL) {
        try {
            return new URI(thisURL);
        } catch (URISyntaxException e) {
            lukaLog(1, "Error creating URL! URL: " + thisURL);
            return null;
        }
    }

    public static void openLink(URI hyperlink) {
        try{
            Desktop.getDesktop().browse(hyperlink);
        }catch(IOException e){
            lukaLog(1,"There was an error trying to open a URL in the browser. URL: " + hyperlink);
        }
    }

    private static String makeUUID(){
        lukaLog(0, "generating uuid..");
        UUID renameID = UUID.fromString("38400000-8cf0-11bd-b23e-10b96e4ef00d");
        lukaLog(2, "uuid created..  "+ renameID);
        return renameID.randomUUID().toString();
    }

    private static void deleteMe(File fileToDelete) {
        //credit to Jeff Learman on StackOverflow for this method
        File[] contents = fileToDelete.listFiles();
        if (contents != null) {
            for (File f : contents) {
                if (! Files.isSymbolicLink(f.toPath())) {
                    deleteMe(f);
                }
            }
        }
        fileToDelete.delete();
    }

    private static String readFile(String filePath){
        String overallContents = "";
        String fileContents = null;
        try {
            BufferedReader readFile = new BufferedReader(new FileReader(filePath));
            fileContents = readFile.readLine();
            while (fileContents != null) {
                overallContents += fileContents + System.getProperty("line.separator");;
                fileContents = readFile.readLine();
            }
            readFile.close();
            lukaLog(0, "successfully read file contents from [" + filePath + "]!");
        } catch (IOException e) {
            lukaLog(1, "error reading. setting [" + filePath + "] to errored state.. " + e.toString());
            overallContents = "errored";
        }
        return overallContents;
    }

    private static void writeFile(String filePath, String fileContents){
        File outputFile = new File(filePath);
        boolean outputExist = outputFile.exists();
        if(!outputExist) {
            try {
                outputFile.createNewFile();
            } catch (IOException e) {
                lukaLog(1, "there was an error creating the file [" + filePath + "].");
            }
        }

        try{
            FileWriter writeFile = new FileWriter(filePath);
            writeFile.write(fileContents);
            writeFile.close();
            lukaLog(0, "successfully wrote new file contents to [" + filePath + "]!");
        }catch (IOException e) {
            lukaLog(1, "error writing, so writing nothing... " + e.toString());
        }
    }

    private static void copyDirectory(File sourceFolder, File destinationFolder) throws IOException {

        //Check if sourceFolder is a directory or file
        //If sourceFolder is file; then copy the file directly to new location
        if (sourceFolder.isDirectory())
        {
            //Verify if destinationFolder is already present; If not then create it
            if (!destinationFolder.exists())
            {
                destinationFolder.mkdir();
                System.out.println("Directory created :: " + destinationFolder);
            }

            //Get all files from source directory
            String files[] = sourceFolder.list();

            //Iterate over all files and copy them to destinationFolder one by one
            for (String file : files)
            {
                File srcFile = new File(sourceFolder, file);
                File destFile = new File(destinationFolder, file);

                //Recursive function call
                copyDirectory(srcFile, destFile);
            }
        }
        else
        {
            //Copy the file content from one place to another
            Files.copy(sourceFolder.toPath(), destinationFolder.toPath(), StandardCopyOption.REPLACE_EXISTING);
            lukaLog(2, "Copied ... " + destinationFolder);
        }
    }

    private static void copyMod(String optionalPath, String modName){
        try {
            File thisMod = new File(optionalPath + modName);
            Files.copy(thisMod.toPath(),  Paths.get(getLibrary() + File.separator + "mods" + File.separator), StandardCopyOption.REPLACE_EXISTING);
            thisMod.delete();
        }catch(Exception e){
            lukaLog(0, "Error transporting optional file... " + e);
        }
    }

    private static String thisDirectory() {
        try {
            String fullPath = (Main.class.getProtectionDomain().getCodeSource().getLocation().toURI()).getPath().toString();
            return fullPath.substring(0, fullPath.indexOf("ModsAtWork.jar"));
        }catch(Exception e){
            lukaLog(1, "error with getting jar's location..");
            return null;
        }
    }



    /* installation steps methods */
    public static void startProcess(){
        firstFrame = new Backup();
        firstFrame.setVisible(true);
    }

    public static void stepOne(boolean cleanTrue){

        lukaLog(0, "stage one starting c:<");

        String mainDirectory = getLibrary();
        ArrayList modifiedDirectories = new ArrayList();
        modifiedDirectories.add(mainDirectory + File.separator + "mods");
        modifiedDirectories.add(mainDirectory + File.separator + "Flan");
        modifiedDirectories.add(mainDirectory + File.separator + "logs");
        modifiedDirectories.add(mainDirectory + File.separator + "config");
        modifiedDirectories.add(mainDirectory + File.separator + "modpack");
        modifiedDirectories.add(mainDirectory + File.separator + "mod-config");
        modifiedDirectories.add(mainDirectory + File.separator + "crash-reports");
        modifiedDirectories.add(mainDirectory + File.separator + "journey-map");
        modifiedDirectories.add(mainDirectory + File.separator + "shaderpacks");
        modifiedDirectories.add(mainDirectory + File.separator + "journey-map");

        ArrayList modifiedFiles = new ArrayList();
        modifiedFiles.add(mainDirectory + File.separator + "TooManyItems.txt");
        modifiedFiles.add(mainDirectory + File.separator + "BotaniaVars.dat");
        modifiedFiles.add(mainDirectory + File.separator + "optionsshaders.txt");

        String renameID = null;
        if(!cleanTrue){
            lukaLog(0, "generating unique id to rename files..");
            renameID = makeUUID();
        }

        for(int i = 0; i < modifiedDirectories.size(); i++){
            if(cleanTrue){
                File currentDir = new File(modifiedDirectories.get(i).toString());
                deleteMe(currentDir);
                lukaLog(0, "deleted " + modifiedDirectories.get(i).toString());
            }else{
                File currentDir = new File(modifiedDirectories.get(i).toString());
                currentDir.renameTo(new File(currentDir + "_" + modpack + "_OLD_" + renameID));
                lukaLog(0, "renamed " + modifiedDirectories.get(i).toString() + " -> " + modifiedDirectories.get(i).toString() + "_" + modpack + "_OLD_" + renameID);
            }
        }

        for(int i = 0; i < modifiedFiles.size(); i++){
            if(cleanTrue){
                File currentDir = new File(modifiedFiles.get(i).toString());
                deleteMe(currentDir);
                lukaLog(0, "deleted " + modifiedFiles.get(i).toString());
            }else{
                File currentDir = new File(modifiedFiles.get(i).toString());
                currentDir.renameTo(new File(currentDir + "_" + modpack + "_OLD_" + renameID));
                lukaLog(0, "renamed " + modifiedFiles.get(i).toString() + " -> " + modifiedFiles.get(i).toString() + "_" + modpack + "_OLD_" + renameID);
            }
        }

        lukaLog(0, "stage one complete c:");
        firstFrame.setVisible(false);
        secondFrame = new Forge();
        secondFrame.setVisible(true);

    }

    public static void stepTwo(boolean skip) throws IOException, InterruptedException {

        lukaLog(0, "stage two starting c:<");

        if(!skip) {
            File forgeInstaller = new File(thisDirectory() + "Forge" + File.separator + "ForgeInstaller.exe");
            Runtime.getRuntime().exec(forgeInstaller.getAbsolutePath());
            TimeUnit.SECONDS.sleep(3);
        }

        lukaLog(0, "stage two complete c:");
        secondFrame.setVisible(false);
        thirdFrame = new Profile();
        thirdFrame.setVisible(true);

    }

    public static void stepThree(String profileName, String profileMin, String profileMax, String profileIcon) {

        lukaLog(0, "stage three starting c:<");

        File launcherProfiles = new File(getLibrary() + File.separator + "launcher_profiles.json");
        String searchFor = "\"selectedUser\"";

        lukaLog(0, "adding profile to launcher...");
        String profileID = modpack + "uuid" + makeUUID().replace("-", "");
        String created = "2019-05-25T22:45:13.139Z";
        String icon = profileIcon;
        String javaArgs = "-Xms" + profileMin + "G -Xmx" + profileMax + "G";
        String lastUsed = "2019-08-08T01:26:21.941Z";
        String lastVersionID = "1.12.2-forge1.12.2-14.23.5.2838";
        String name = profileName;
        String type = "custom";
        String newProfile =
                "    \"" + profileID + "\" : {\n" +
                "      \"created\" : \"" + created + "\",\n" +
                "      \"icon\" : \"" + icon + "\",\n" +
                "      \"javaArgs\" : \"" + javaArgs + "\",\n" +
                "      \"lastUsed\" : \"" + lastUsed + "\",\n" +
                "      \"lastVersionId\" : \"" + lastVersionID + "\",\n" +
                "      \"name\" : \"" + name + "\",\n" +
                "      \"type\" : \"" + type + "\"\n" +
                "    }";


        //Main.writeFile(getLibrary() + File.separator + "settings.txt", settingsFormat);
        String fileContents = Main.readFile(launcherProfiles.getAbsolutePath());
        int insertIndex = fileContents.lastIndexOf(searchFor) - 1 - 8;
        String newFileContents =
                fileContents.substring(0, insertIndex) + "," + System.getProperty("line.separator") +
                newProfile + System.getProperty("line.separator") +
                fileContents.substring(insertIndex + 1);

        writeFile(launcherProfiles.getAbsolutePath(), newFileContents);

        lukaLog(0, "stage three complete c:");
        thirdFrame.setVisible(false);
        fourthFrame = new Core();
        fourthFrame.setVisible(true);

    }

    public static void stepFour() throws IOException{

        lukaLog(0, "stage four starting c:<"); //did u make it? i made it!

        try {
            File coreFiles = new File(thisDirectory() + "Core" + File.separator);
            copyDirectory(coreFiles, new File(getLibrary() + File.separator));
            coreFiles.delete();
        }catch(Exception e){
            lukaLog(1, e.toString());
        }

        lukaLog(0, "stage four complete c:");
        fourthFrame.setVisible(false);
        fifthFrame = new Optional();
        fifthFrame.setVisible(true);

    }

    public static void stepFive() throws IOException{

        lukaLog(0, "stage five starting c:<"); //did u make it? i made it!

        //note: kinda made it cleaner with methods? might automate further in future..
        String optionalPath = thisDirectory() + "Optional" + File.separator;
        if(Optional.cbVisuals.isSelected()){ copyMod(optionalPath, "Visuals-1.12.2-7r.jar"); }
        if(Optional.cbMap.isSelected()){ copyMod(optionalPath, "journeymap-1.12.2-5.5.5.jar"); }
        if(Optional.cbClean.isSelected()){ copyMod(optionalPath, "CleanView-1.12.2-v1c.jar"); }
        if(Optional.cbNeat.isSelected()){ copyMod(optionalPath, "Neat+1.4-17.jar"); }
        if(Optional.cbRecipe.isSelected()){ copyMod(optionalPath, "FullscreenWindowed-1.12-1.6.0.jar"); }
        if(Optional.cbSound.isSelected()){ copyMod(optionalPath, "SoundFilters-0.11_for_1.12.jar"); }
        if(Optional.cbYarr.isSelected()){ copyMod(optionalPath, "YarrCuteMobModelsRemake-1.0.16-1.12.0.jar"); }
        if(Optional.cbAmbient.isSelected()){ copyMod(optionalPath, "AmbientSounds_v3.0.9_mc1.12.2.jar"); }
        if(Optional.cbFancy.isSelected()){ copyMod(optionalPath, "Hwyla-1.8.26-B41_1.12.2.jar"); }
        if(Optional.cbHealth.isSelected()){ copyMod(optionalPath, "colorfulhealthbar-0.0.4.jar"); }
        if(Optional.cbDynamic.isSelected()){ copyMod(optionalPath, "DynamicSurroundings-1.12.2-3.5.4.3.jar"); }
        if(Optional.cbDynamic.isSelected()){ copyMod(optionalPath, "DynamicSurroundings-core-1.12.2-3.5.4.3.jar"); }
        if(Optional.cbClient.isSelected()){ copyMod(optionalPath, "MouseTweaks-2.10-mc1.12.2.jar"); }
        if(Optional.cbControl.isSelected()){ copyMod(optionalPath, "SmoothFont-mc1.12.2-2.1.jar"); }
        if(Optional.cbFoilage.isSelected()){ copyMod(optionalPath, "BetterFoliage-MC1.12-2.2.0.jar"); }

        lukaLog(0, "stage five complete c:");
        fifthFrame.setVisible(false);
        endFrame = new Done();
        endFrame.setVisible(true);

    }

    public static void updatePack(){
        showError("updates not supported yet! why click me :c");
    }
}
