package me.lukasong.shaderobsf;

import javax.swing.*;
import java.io.*;
import java.nio.file.*;
import java.nio.file.attribute.BasicFileAttributes;
import java.util.ArrayList;
import java.util.Random;
import java.text.DateFormat;
import java.text.SimpleDateFormat;
import java.util.Date;
import java.util.UUID;
import java.util.concurrent.TimeUnit;
import java.util.zip.ZipEntry;
import java.util.zip.ZipOutputStream;

public class Main {


    /* variables */
    private static String shaderName = "example.shader";
    private static String shaderAuthor = "nadeshiko#0000";
    private static String shaderBuyer = "riamu#0000";
    private static String shaderPath;
    private static String cgFrontPath;
    private static String cgBackPath;
    private static String cgColorPath;
    private static String editorPath;
    private static String databasePath;
    private static String settingsPath;
    private static String outputPath = "n/a";
    private static enum fileType { Shader, CGInclude, Editor };


    /* options */
    private static boolean randomComments ; //toggle
    private static int randomCommentFreq; //higher = less chance, needs reworked
    private static int randomLengthRange;

    private static boolean changeGrabpasses; //toggle
    private static String[] grabPasses;
    private static String[] savePasses;
    private static String[] cleanGrabpasses;

    private static boolean changeTerms; //toggle
    private static boolean randomTerms ; //toggle
    private static boolean avoidComments;
    private static int randomTermsLength = 10;
    private static String[] termsSetOne;  //just put _ and itll recognize it as a property (not required in second part)
    private static String[] termsSetTwo;

    private static boolean tagUUID;
    private static boolean fakeUUID;
    private static String realUUIDstring;
    private static String fakeUUIDstring;

    private static boolean hideGenMark;
    private static boolean zipShader;


    /* global usage */
    private static Random randGen = new Random();
    public static String lineBreak = System.getProperty("line.separator");
    public static String lukaWatermark = "//shader automatically marked by luka#8375 c:";
    public static ArrayList invalidPlaces = new ArrayList();


    /* statistics */
    private static int statComments = 0;
    private static int statGrabpasses = 0;
    private static int statTerms = 0;
    private static long fileSize = 0;


    /* windows */
    public static Window mainFrame;
    public static Progress progressBar;



    /* main method */
    public static void main(String [] args)
    {

        //creating settings if needed
        settingsExist();

        //reading settings
        Settings.ReadSettings();

        //creating window
        progressBar = new Progress();
        mainFrame = new Window();
        mainFrame.setVisible(true);

    }


    /* helper methods */
    public static void lukaLog(int logType, String logMessage) {
        //just formatted logging
        String lukaTag = "[luka shader obsf]";
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

    public static String readFile(String filePath){
        //reads a file
        String overallContents = "";
        String fileContents = null;
        try {
            BufferedReader readFile = new BufferedReader(new FileReader(filePath));
            fileContents = readFile.readLine();
            while (fileContents != null) {
                overallContents += fileContents + lineBreak;
                fileContents = readFile.readLine();
            }
            readFile.close();
            lukaLog(0, "Successfully read file contents from [" + filePath + "]!");
        } catch (IOException e) {
            lukaLog(1, "Error reading. Setting [" + filePath + "] to errored state. Error trace: " + e.toString());
            overallContents = "errored";
        }
        return overallContents;
    }

    public static void writeFile(String filePath, String fileContents){
        //writes a file
        File outputFile = new File(filePath);
        boolean outputExist = outputFile.exists();
        if(!outputExist) {
            try {
                outputFile.createNewFile();
            } catch (IOException e) {
                lukaLog(1, "There was an error creating the file [" + filePath + "].");
            }
        }

        try{
            FileWriter writeFile = new FileWriter(filePath);
            writeFile.write(fileContents);
            writeFile.close();
            lukaLog(0, "Successfully wrote new file contents to [" + filePath + "]!");
        }catch (IOException e) {
            lukaLog(1, "Error writing. Writing nothing. Error trace: " + e.toString());
        }
    }

    private static char randomCharacter(boolean excludeNumbers){
        //returns a random character, A-Z, a-z, 0-9
        String possibleCharaters =
                "ABCDEFGHIJKLMNOPQRSTUVWXYZ" +
                "abcdefghijklmnopqrstuvwxyz";
        if(!excludeNumbers) possibleCharaters += "123456789";
        return possibleCharaters.charAt(randGen.nextInt(possibleCharaters.length()));
    }

    private static boolean duplicateCheck(String term, String[] termArray){
        boolean duplicate = false;
        term = term.toLowerCase();
        for(int i = 0; i < termArray.length; i++){
            if(termArray[i].toLowerCase().equals(term)){
                duplicate = false;
                break;
            }
        }
        return duplicate;
    }

    private static String getDate(){
        DateFormat dateFormatting = new SimpleDateFormat("dd/MM/yyyy HH:mm");
        Date currnetDate = new Date();
        return dateFormatting.format(currnetDate);

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

    public static void settingsExist(){
        lukaLog(0, "Checking if settings file exists..");
        boolean settingsExist = new File(Settings.getLibrary() + File.separator + "settings.txt").isFile();
        if(!settingsExist){
            lukaLog(2, "Settings file does not exist!");
            Settings.CreateSettings();
            lukaLog(2, "Settings file created!");
        }else{
            lukaLog(2, "Settings file exists!");
        }
    }

    public static void makeDirectory(String pathToMake){
        Path settingsPath = Paths.get(pathToMake);
        if(!Files.exists(settingsPath)) new File(settingsPath.toString()).mkdirs();
    }

    public static void showError(String errorMessage){
        JOptionPane.showMessageDialog(null, lukaRainbowfy("Uh oh.. error! :c  ") + errorMessage, "luka#8375 shader obfuscator",JOptionPane.INFORMATION_MESSAGE);
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

    private static void defineBadLines(){
        invalidPlaces.clear();
        invalidPlaces.add("#");
        invalidPlaces.add("frag");
        invalidPlaces.add("vert");
        invalidPlaces.add("fallback");
        invalidPlaces.add("cg");
        invalidPlaces.add("customeditor");
        invalidPlaces.add("pass");
        invalidPlaces.add("cull");
        invalidPlaces.add("ztest");
        invalidPlaces.add("shader");
        invalidPlaces.add("tags");
        invalidPlaces.add("}");
        invalidPlaces.add("{");
        invalidPlaces.add("properties");
        invalidPlaces.add("\"");
    }

    private static long getMegabytes(String filePath){
        File thisFile = new File(filePath);
        long fileSize = thisFile.length() / 1000;
        return fileSize;
    }


    /* obfuscation methods */
    private static String genRandomComment(boolean isStatic, int intStatic, boolean excludeNumbers){
        String comment = "//";
        int commentLength = intStatic;
        if(isStatic == false) commentLength = randGen.nextInt(randomLengthRange) + 1;
        for (int i = 0; i < commentLength; i++){
            comment += randomCharacter(excludeNumbers);
        }
        return comment;
    }

    private static String applyRandomComment(String fileContents){
        lukaLog(0, "Starting random comment function.");
        int lines = fileContents.length() - fileContents.replace(lineBreak,"").length() - 1;
        lukaLog(0, String.valueOf(lines));
        String[] brokenUp = fileContents.split(System.getProperty("line.separator"));
        lukaLog(0, String.valueOf(brokenUp.length));
        String newString = "";
        lukaLog(0, "Message split up for random comments to be applied.");
        for (int i = 0; i < lines; i++){
            try {
                int commentOrNo = randGen.nextInt(lines * 2) + 1;
                newString += brokenUp[i];
                if (commentOrNo < randomCommentFreq * (lines / 4) && checkLine(brokenUp[i].toLowerCase())) {
                    if(avoidComments && ( brokenUp[i].contains("//") ||  brokenUp[i].contains("/*"))){
                        lukaLog(2, "Skipping because avoid comments is on and line contains a comment! [" + i + "]");
                    }else{
                        lukaLog(0, "Applied random comment on line [" + i + "]");
                        newString += lineBreak + genRandomComment(false, 0, false);
                        statComments++;
                    }
                }
                newString += lineBreak;
            }catch(Exception e){
               // lukaLog(0, "Error copying line " + i + ", probably due to Windows.");
            }
        }
        lukaLog(0, "Returning file contents with " + statComments + " random comments applied.");
        return newString;
    }

    private static void makeGrabpasses(){
        lukaLog(0, "Creating new grabpass names..");
        for(int i = 0; i < grabPasses.length; i++){
            String newGrabpass = grabPasses[i];
            newGrabpass += genRandomComment(true, 5, false).replace("//", "_");
            savePasses[i] = newGrabpass;
            lukaLog(0, grabPasses[i] + " -> " + newGrabpass);
        }
        lukaLog(0, "New grabpass names were created!");
    }

    private static String replaceGrabpasses(String fileContents){
        lukaLog(0, "Starting grabpass change function.");
        String newFileContents = fileContents;
        for(int i = 0; i < grabPasses.length; i++){
            lukaLog(0, "Searching for grabpass " + cleanGrabpasses[i]);
            statGrabpasses += newFileContents.length() - newFileContents.replaceAll(cleanGrabpasses[i], "").length();
            newFileContents = newFileContents.replaceAll(cleanGrabpasses[i], savePasses[i]);
            lukaLog(0, "Replaced all instances of " + cleanGrabpasses[i] + " with " + savePasses[i] + ".");
        }
        lukaLog(0, "Returning file contents with grabpasses changed. Changed " + statGrabpasses + " instances.");
        return newFileContents;
    }

    private static void makeTerms(){
        //random terms?
        lukaLog(0, "Starting random term replacement.");
        for(int i = 0; i < termsSetTwo.length; i++) {
            boolean dupCheck = true;
            String thisTerm = termsSetTwo[i];
            while(dupCheck) {
                thisTerm = genRandomComment(true, randomTermsLength, true).replace("//", "");
                lukaLog(0, "Checking random duplicate for term.. " + thisTerm + "");
                dupCheck = duplicateCheck(thisTerm, termsSetTwo);
            }
            termsSetTwo[i] = thisTerm;
            lukaLog(0, "Random replacement duplicate check for " + thisTerm + " passed!");
        }
        String totalArray = "";
        for(int i = 0; i < termsSetTwo.length; i++) { //this is pure for logging, can be deleted for optimization
            totalArray += termsSetTwo[i] + ", ";
        }
        lukaLog(0, "Random terms finished being generated, heres the result: " + totalArray);

    }

    private static String replaceTerms(String fileContents){
        //determining if property
        lukaLog(0, "Starting random term replacement.");
        for(int i = 0; i < termsSetOne.length; i++){
            if(termsSetOne[i].startsWith("_")){
                if(!(termsSetTwo[i].startsWith("_"))){
                    termsSetTwo[i] = "_" + termsSetTwo[i];
                }
            }
        }

        //applying
        lukaLog(0, "Starting term replace function.");
        String newFileContents = fileContents;
        for(int i = 0; i < termsSetOne.length; i++){
            statTerms += newFileContents.length() - newFileContents.replaceAll(termsSetOne[i], "").length();
            newFileContents = newFileContents.replaceAll(termsSetOne[i], termsSetTwo[i]);
            lukaLog(0, "Replaced all instances of " + termsSetOne[i] + " with " + termsSetTwo[i] + ".");
        }
        lukaLog(0, "Returning file contents with terms changed. Changed " + statTerms + " instances.");
        return newFileContents;
    }

    private static void makeUUID(boolean fakeUUID){
        //applying fake id if needed
        if(fakeUUID){
            lukaLog(0, "Generating fake UUID..");
            UUID userID = UUID.fromString("38400000-8cf0-11bd-b23e-10b96e4ef00d");
            fakeUUIDstring =  userID.randomUUID().toString();
            lukaLog(1, "Fake UUID created! (Fake) UUID: " + fakeUUIDstring);
        }
        //real uuid
        lukaLog(0, "Generating real UUID..");
        UUID userID = UUID.fromString("38400000-8cf0-11bd-b23e-10b96e4ef00d");
        realUUIDstring = userID.randomUUID().toString();
        lukaLog(1, "Real UUID generated!");
    }

    private static String tagUUID(boolean fakeUUID, String fileContents){
        //applying fake id if needed
        if(fakeUUID){
            lukaLog(0, "Appending file to fake UUID..");
            fileContents = fileContents + lineBreak + "//shader uuid: " + fakeUUIDstring;
            lukaLog(0, "Fake UUID applied!");
        }


        int lines = fileContents.length() - fileContents.replace(lineBreak,"").length();
        String[] brokenUp = fileContents.split(System.getProperty("line.separator"));
        String newString = "";
        boolean uuidApplied = false;
        while(uuidApplied == false) {
            newString = "";
            lukaLog(0, "Running through file.. trying for real random uuid");
            for (int i = 0; i < lines; i++) {
                try {
                    int uuidTestOne = randGen.nextInt(lines) + 1;
                    int uuidTestTwo = randGen.nextInt(lines) + 1;
                    newString += brokenUp[i];
                    if (uuidTestOne == uuidTestTwo && uuidApplied == false && checkLine(brokenUp[i].toLowerCase())) {
                        lukaLog(0, "Real UUID match! Line: [" + i + "]");
                        newString += lineBreak + "//" + realUUIDstring ;
                        uuidApplied = true;
                        lukaLog(0, "Real UUID applied!");
                    }
                    newString += lineBreak;
                }catch(Exception e){
                   // lukaLog(0, "Error copying line " + i + ", probably due to Windows.");
                }
            }
        }
        return newString;
    }

    private static String addWatermark(String fileContents){
        return fileContents + lineBreak + lukaWatermark;
    }

    private static boolean checkLine(String line){ //true = good
        for(int i = 0; i < invalidPlaces.size(); i++){
            if(line.contains(invalidPlaces.get(i).toString())){
                return false;
            }
        }
        return true;
    }


    /* finalization methods */
    private static void makeOutput(String filePath){
        lukaLog(0, "Starting output message..");
        File outputFile = new File(filePath);
        boolean outputExist = outputFile.exists();
        String previousContents = readFile(filePath);
        String outputMessage = "";
        String shaderZipMessage = "shader in file format";
        if(zipShader) shaderZipMessage = "shader in zip format, size: " + fileSize + " mb";
        if(!outputExist)
            outputMessage += "luka#8375 shader obfuscator" + lineBreak + "----------------------------------" + lineBreak + lineBreak + lineBreak;
        outputMessage += lineBreak + lineBreak + lineBreak;
        outputMessage +=
                "----------------------------------" + lineBreak +
                shaderName + " obfuscation on " + getDate() + lineBreak +
                "shader author: " + shaderAuthor + lineBreak +
                "shader buyer: " + shaderBuyer + lineBreak +
                shaderZipMessage + lineBreak +
                "shader output directory: " + Directory.tfOutput.getText() + lineBreak +
                "shader main input directory: " + Directory.tfMain.getText() + lineBreak +
                "----------------------------------" + lineBreak;
        outputMessage +=
                "Random Comments: " + randomComments + lineBreak;
                 if(randomComments) outputMessage += "  >Comments Produced: " + statComments + lineBreak;
        outputMessage +=
                "Grabpass Changed: " + changeGrabpasses + lineBreak;
                if(changeGrabpasses) {
                    outputMessage += "  >Grabpasses Changed: " + statGrabpasses + lineBreak;
                    for(int i = 0; i < grabPasses.length; i++){
                        outputMessage += "  >Replaced: " + cleanGrabpasses[i] + " -> " + savePasses[i] + lineBreak;
                    }
                }
         outputMessage +=
                "Terms Replaced: " + changeTerms + lineBreak;
                if(changeTerms) {
                    outputMessage += "  >Randomize Terms: " + randomTerms + lineBreak;
                    outputMessage += "  >Terms Changed: " + statTerms + lineBreak;

                    for (int i = 0; i < termsSetOne.length; i++) {
                        outputMessage += "  >Replaced: " + termsSetOne[i] + " -> " + termsSetTwo[i] + lineBreak;
                    }
                }
         outputMessage +=
                 "Generate UUID: " + tagUUID + lineBreak;
                 if(tagUUID){
                     outputMessage += "  >User UUID: " + realUUIDstring + lineBreak;
                     outputMessage += "  >Fake UUID: " + fakeUUID + lineBreak;
                     if(fakeUUID) outputMessage += "  >Fake UUID: " + fakeUUIDstring + lineBreak;
                 }
         if(!hideGenMark) outputMessage += "shader obsfucation provided by luka#8375" + lineBreak;
         outputMessage += "----------------------------------";
         String thisOutput = outputMessage;
         if(outputExist) outputMessage = previousContents + outputMessage;
         writeFile(filePath, outputMessage);
         lukaLog(0, "Output file succesfully wrote to... pasting output.");
         lukaLog(1, thisOutput);
    }

    private static void zipFile(final Path folder, final Path zipFilePath) throws IOException {
        lukaLog(0, "Zipping " + folder.toString() + " -> " + zipFilePath.toString());
        try {
            try (
                    FileOutputStream fos = new FileOutputStream(zipFilePath.toFile());
                    ZipOutputStream zos = new ZipOutputStream(fos)
            ) {
                Files.walkFileTree(folder, new SimpleFileVisitor<Path>() {
                    public FileVisitResult visitFile(Path file, BasicFileAttributes attrs) throws IOException {
                        zos.putNextEntry(new ZipEntry(folder.relativize(file).toString()));
                        Files.copy(file, zos);
                        zos.closeEntry();
                        return FileVisitResult.CONTINUE;
                    }

                    public FileVisitResult preVisitDirectory(Path dir, BasicFileAttributes attrs) throws IOException {
                        zos.putNextEntry(new ZipEntry(folder.relativize(dir).toString() + "/"));
                        zos.closeEntry();
                        return FileVisitResult.CONTINUE;
                    }
                });
            }
            lukaLog(2, "Zipped!");
        }catch(Exception e){
            lukaLog(2, "Error zipping, see error trace: " + e);
            showError("There was an error zipping..");
        }
    }

    public static void applyObfuscation(){

        //setting up before, if needed
        defineBadLines();
        Progress.updateProgress("Reading settings..", 0);
        if(Window.cbGrabpass.isSelected()){
            grabPasses = Window.tfGrabpasses.getText().replace(" ", "").split(",");
            savePasses = grabPasses;
            cleanGrabpasses = grabPasses.clone();
            for(int i = 0; i < grabPasses.length; i++) lukaLog(0, grabPasses[i]);
            makeGrabpasses();
        }
        if(Window.cbTerms.isSelected() && Window.cbRandomTerms.isSelected()){
            randomTerms = Window.cbRandomTerms.isSelected();
            termsSetOne = Window.tfTermsOne.getText().replace(" ", "").split(",");
            termsSetTwo = Window.tfTermsTwo.getText().replace(" ", "").split(",");
            makeTerms();
        }
        if(Window.cbUUID.isSelected()){
            fakeUUID = Window.cbFakeUUID.isSelected();
            makeUUID(fakeUUID);
        }
        String newMainDirectory = Directory.tfOutput.getText() + File.separator;
        newMainDirectory.replace("/", File.separator);
        String buyerDirectory = newMainDirectory + Window.tfBuyer.getText() + File.separator + "src";
        String mainDirectory = newMainDirectory + Window.tfBuyer.getText();
        makeDirectory(buyerDirectory + File.separator);

        //applying settings
        Progress.updateProgress("Creating a force field..", 3);
        if(Window.cbComments.isSelected()) {
            try {
                avoidComments = Window.cbCommentsAvoid.isSelected();
                randomCommentFreq = Integer.parseInt(Window.tfCommentAmount.getText());
                randomLengthRange = Integer.parseInt(Window.tfCommentLength.getText());
            }catch(Exception e){
                lukaLog(1, "Error applying random comment settings!");
                showError("Please enter integers for the random comment settings!");
                return;
            }
        }

        try{
            changeGrabpasses = Window.cbGrabpass.isSelected();
            changeTerms = Window.cbTerms.isSelected();
            randomComments = Window.cbComments.isSelected();
            tagUUID = Window.cbUUID.isSelected();
            shaderAuthor = Window.tfAuthor.getText();
            shaderBuyer = Window.tfBuyer.getText();
            shaderName = Directory.tfName.getText();
            zipShader = Window.cbZip.isSelected();
            hideGenMark = Window.cbWatermark.isSelected();
        }catch(Exception e){
            lukaLog(1, "Error applying general settings!");
            showError("Please enter valid settings!");
            return;
        }
        Progress.updateProgress("Forcefield made, settings read!", 5);


        //resources
        if(!Directory.tfResource.getText().isEmpty()){
            String soSpecific =  Directory.tfResource.getText().substring(Directory.tfMain.getText().length());
            String newSoDir = buyerDirectory + soSpecific;
            makeDirectory(newSoDir);
            try {
                copyDirectory(new File(Directory.tfResource.getText()), new File(newSoDir));
                lukaLog(0, "Directory was copied!");
            } catch (Exception e) {
                lukaLog(1, "There was an error copying resource directories.. here it goes ~ " + e);
                showError("There was an error copying resource directories.. aborting :/");
            }
            Progress.updateProgress("Resources copied...", 15);
        }

        //shader one (=so lol)
        if(!Directory.tfShader.getText().isEmpty()){
            String soSpecific =  Directory.tfShader.getText().substring(Directory.tfMain.getText().length());
            String newSoDir = buyerDirectory + soSpecific;
            String soDir = Directory.tfShader.getText();
            String soFileContents = readFile(soDir);
            if(Window.cbComments.isSelected()) soFileContents = applyRandomComment(soFileContents);
            if(Window.cbTerms.isSelected()) soFileContents = replaceTerms(soFileContents);
            if(Window.cbGrabpass.isSelected()) soFileContents = replaceGrabpasses(soFileContents);
            if(Window.cbUUID.isSelected()) soFileContents = tagUUID(fakeUUID, soFileContents);
            if(Window.cbWatermark.isSelected()) soFileContents = addWatermark(soFileContents);
            makeDirectory(newSoDir.substring(0, newSoDir.lastIndexOf(File.separator)));
            writeFile(newSoDir, soFileContents);
            Progress.updateProgress("Shader one created...", 25);
        }


        //shader two
        if(!Directory.tfShaderTwo.getText().isEmpty()){
            String soSpecific =  Directory.tfShaderTwo.getText().substring(Directory.tfMain.getText().length());
            String newSoDir = buyerDirectory + soSpecific;
            String soDir = Directory.tfShaderTwo.getText();
            String soFileContents = readFile(soDir);
            if(Window.cbComments.isSelected()) soFileContents = applyRandomComment(soFileContents);
            if(Window.cbTerms.isSelected()) soFileContents = replaceTerms(soFileContents);
            if(Window.cbGrabpass.isSelected()) soFileContents = replaceGrabpasses(soFileContents);
            if(Window.cbUUID.isSelected()) soFileContents = tagUUID(fakeUUID, soFileContents);
            if(Window.cbWatermark.isSelected()) soFileContents = addWatermark(soFileContents);
            makeDirectory(newSoDir.substring(0, newSoDir.lastIndexOf(File.separator)));
            writeFile(newSoDir, soFileContents);
            Progress.updateProgress("Shader two created...", 35);
        }

        //shader three
        if(!Directory.tfShaderThree.getText().isEmpty()){
            String soSpecific =  Directory.tfShaderThree.getText().substring(Directory.tfMain.getText().length());
            String newSoDir = buyerDirectory + soSpecific;
            String soDir = Directory.tfShaderThree.getText();
            String soFileContents = readFile(soDir);
            if(Window.cbComments.isSelected()) soFileContents = applyRandomComment(soFileContents);
            if(Window.cbTerms.isSelected()) soFileContents = replaceTerms(soFileContents);
            if(Window.cbGrabpass.isSelected()) soFileContents = replaceGrabpasses(soFileContents);
            if(Window.cbUUID.isSelected()) soFileContents = tagUUID(fakeUUID, soFileContents);
            if(Window.cbWatermark.isSelected()) soFileContents = addWatermark(soFileContents);
            makeDirectory(newSoDir.substring(0, newSoDir.lastIndexOf(File.separator)));
            writeFile(newSoDir, soFileContents);
            Progress.updateProgress("Shader three created...", 45);
        }

        //cg one
        if(!Directory.tfCGOne.getText().isEmpty()){
            String soSpecific =  Directory.tfCGOne.getText().substring(Directory.tfMain.getText().length());
            String newSoDir = buyerDirectory + soSpecific;
            String soDir = Directory.tfCGOne.getText();
            String soFileContents = readFile(soDir);
            if(Window.cbComments.isSelected()) soFileContents = applyRandomComment(soFileContents);
            if(Window.cbTerms.isSelected()) soFileContents = replaceTerms(soFileContents);
            if(Window.cbGrabpass.isSelected()) soFileContents = replaceGrabpasses(soFileContents);
            if(Window.cbUUID.isSelected()) soFileContents = tagUUID(fakeUUID, soFileContents);
            if(Window.cbWatermark.isSelected()) soFileContents = addWatermark(soFileContents);
            makeDirectory(newSoDir.substring(0, newSoDir.lastIndexOf(File.separator)));
            writeFile(newSoDir, soFileContents);
            Progress.updateProgress("CGInclude one created...", 55);
        }

        //cg two
        if(!Directory.tfCGTwo.getText().isEmpty()){
            String soSpecific =  Directory.tfCGTwo.getText().substring(Directory.tfMain.getText().length());
            String newSoDir = buyerDirectory + soSpecific;
            String soDir = Directory.tfCGTwo.getText();
            String soFileContents = readFile(soDir);
            if(Window.cbComments.isSelected()) soFileContents = applyRandomComment(soFileContents);
            if(Window.cbTerms.isSelected()) soFileContents = replaceTerms(soFileContents);
            if(Window.cbGrabpass.isSelected()) soFileContents = replaceGrabpasses(soFileContents);
            if(Window.cbUUID.isSelected()) soFileContents = tagUUID(fakeUUID, soFileContents);
            if(Window.cbWatermark.isSelected()) soFileContents = addWatermark(soFileContents);
            makeDirectory(newSoDir.substring(0, newSoDir.lastIndexOf(File.separator)));
            writeFile(newSoDir, soFileContents);
            Progress.updateProgress("CGInclude two created...", 65);
        }

        //cg three
        if(!Directory.tfCGThree.getText().isEmpty()){
            String soSpecific =  Directory.tfCGThree.getText().substring(Directory.tfMain.getText().length());
            String newSoDir = buyerDirectory + soSpecific;
            String soDir = Directory.tfCGThree.getText();
            String soFileContents = readFile(soDir);
            if(Window.cbComments.isSelected()) soFileContents = applyRandomComment(soFileContents);
            if(Window.cbTerms.isSelected()) soFileContents = replaceTerms(soFileContents);
            if(Window.cbGrabpass.isSelected()) soFileContents = replaceGrabpasses(soFileContents);
            if(Window.cbUUID.isSelected()) soFileContents = tagUUID(fakeUUID, soFileContents);
            if(Window.cbWatermark.isSelected()) soFileContents = addWatermark(soFileContents);
            makeDirectory(newSoDir.substring(0, newSoDir.lastIndexOf(File.separator)));
            writeFile(newSoDir, soFileContents);
            Progress.updateProgress("CGInclude three created...", 75);
        }

        //editor
        if(!Directory.tfEditor.getText().isEmpty()){
            String soSpecific =  Directory.tfEditor.getText().substring(Directory.tfMain.getText().length());
            String newSoDir = buyerDirectory + soSpecific;
            String soDir = Directory.tfEditor.getText();
            String soFileContents = readFile(soDir);
            if(Window.cbComments.isSelected()) soFileContents = applyRandomComment(soFileContents);
            if(Window.cbTerms.isSelected()) soFileContents = replaceTerms(soFileContents);
            if(Window.cbGrabpass.isSelected()) soFileContents = replaceGrabpasses(soFileContents);
            if(Window.cbUUID.isSelected()) soFileContents = tagUUID(fakeUUID, soFileContents);
            if(Window.cbWatermark.isSelected()) soFileContents = addWatermark(soFileContents);
            makeDirectory(newSoDir.substring(0, newSoDir.lastIndexOf(File.separator)));
            writeFile(newSoDir, soFileContents);
            Progress.updateProgress("Editor created...", 85);
        }

        //zip
        if(zipShader){
            try {
                zipFile(Paths.get(buyerDirectory), Paths.get(mainDirectory + File.separator + shaderName + " for " + shaderBuyer + ".zip"));
                Progress.updateProgress("Zipped contents...", 95);
            }catch(IOException e){ }
        }

        //get file size
        if(zipShader) {
            fileSize = getMegabytes(mainDirectory + File.separator + shaderName + " for " + shaderBuyer + ".zip");
        }else{
            fileSize = getMegabytes(buyerDirectory  );
        }

        //log
        makeOutput(Directory.tfOutput.getText() + File.separator + "database.txt");
        Progress.updateProgress("Log made.. done...", 100);
        progressBar.setVisible(true);




        //original testing code :D
        //File(System.getProperty("user.home"), "Desktop");
        // filePath = System.getProperty("user.home") + "/Desktop/test.txt";
        //String outputPath = System.getProperty("user.home") + "/Desktop/output.txt";
        //shaderName = filePath.substring(filePath.lastIndexOf("/") + 1);
        //String readMe = readFile(filePath);
        //readMe = applyRandomComment(readMe);
        //readMe = replaceGrabpasses(readMe);
        //readMe = replaceTerms(readMe);
        //writeFile(filePath, readMe);
        //readMe = tagUUID(true, readMe);
        //Settings.ReadSettings();
        //obsfGUI.setVisible(true);
        //makeOutput(outputPath);


    }

}
