package me.lukasong.shaderobsf;

import org.omg.CORBA.Current;

import java.io.File;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

public class Settings {

    public static String getLibrary(){
        String operatingSystem = System.getProperty("os.name").toLowerCase();
        boolean systemWindows = operatingSystem.contains("window");
        boolean systemMac = operatingSystem.contains("mac");
        String path = null;
        if(systemWindows){
            path = System.getenv("APPDATA") + File.separator + "LukaSong" + File.separator + "Obsf";
        }else if(systemMac){
            path =  System.getProperty("user.home") + File.separator + "Library" + File.separator + "Application Support" + File.separator + "LukaSong" + File.separator + "Obsf";
        }
        Path settingsPath = Paths.get(path);
        if(!Files.exists(settingsPath)) new File(settingsPath.toString()).mkdirs();
        return path;
    }

    public static String settingsFormat =
            "RandomComment:" + "" + Main.lineBreak +
            "RandMaxLength:" + "" + Main.lineBreak +
            "RandFreq:" + "" + Main.lineBreak +
            "Grabpass:" + "" + Main.lineBreak +
            "GrabpassList:" + "" + Main.lineBreak +
            "ReplaceTerms:" + "" + Main.lineBreak +
            "RandomizeTerms:" + "" + Main.lineBreak +
            "TermsOneList:" + "" + Main.lineBreak +
            "TermsTwoList:" + "" + Main.lineBreak +
            "UUID:" + "" + Main.lineBreak +
            "FakeUUID:" + "" + Main.lineBreak +
            "ZipFile:" + "" + Main.lineBreak +
            "Watermark:" + "" + Main.lineBreak +
            "Author:" + "" + Main.lineBreak +
            "Buyer:" + "" + Main.lineBreak +
            "PathShaderOne:" + "" + Main.lineBreak +
            "PathShaderTwo:" + "" + Main.lineBreak +
            "PathShaderThree:" + "" + Main.lineBreak +
            "PathCGOne:" + "" + Main.lineBreak +
            "PathCGTwo:" + "" + Main.lineBreak +
            "PathCGThree:" + "" + Main.lineBreak +
            "PathEditor:" + "" + Main.lineBreak +
            "PathResource:" + "" + Main.lineBreak +
            "PathOutput:" + "" + Main.lineBreak +
            "PathLog:" + "" + Main.lineBreak +
            "ShaderName:" + "" + Main.lineBreak +
            "Main:" + "" + Main.lineBreak +
            "AvoidComments:" + "" + Main.lineBreak;

    public static void CreateSettings(){
        Main.writeFile(getLibrary() + File.separator + "settings.txt", settingsFormat);
    }

    public static void ReadSettings(){
        String fileContents = Main.readFile(getLibrary() + File.separator + "settings.txt");
        Main.lukaLog(0, "Breaking up settings file by line..");
        int lines = fileContents.length() - fileContents.replace(Main.lineBreak,"").length();
        String[] brokenUp = fileContents.split(System.getProperty("line.separator"));
        String newString = "";
        Main.lukaLog(0, "Reading line by line.");
        for (int i = 0; i < lines; i++){
            try {
                String currentSetting = brokenUp[i].toLowerCase();
                String caseSetting = brokenUp[i];
                String setTo = null;
                if (currentSetting.startsWith("randomcomment:")) {
                    setTo = caseSetting.substring("randomcomment:".length());
                    Window.cbComments.setSelected(Boolean.valueOf(setTo));
                } else if (currentSetting.startsWith("randmaxlength:")) {
                    setTo = caseSetting.substring("randmaxlength:".length());
                    Window.tfCommentLength.setText(setTo);
                } else if (currentSetting.startsWith("randfreq:")) {
                    setTo = caseSetting.substring("randfreq:".length());
                    Window.tfCommentAmount.setText(setTo);
                } else if (currentSetting.startsWith("grabpass:")) {
                    setTo = caseSetting.substring("grabpass:".length());
                    Window.cbGrabpass.setSelected(Boolean.valueOf(setTo));
                } else if (currentSetting.startsWith("grabpasslist:")) {
                    setTo = caseSetting.substring("grabpasslist:".length());
                    Window.tfGrabpasses.setText(setTo);
                } else if (currentSetting.startsWith("replaceterms:")) {
                    setTo = caseSetting.substring("replaceterms:".length());
                    Window.cbTerms.setSelected(Boolean.valueOf(setTo));
                } else if (currentSetting.startsWith("randomizeterms:")) {
                    setTo = caseSetting.substring("randomizeterms:".length());
                    Window.cbRandomTerms.setSelected(Boolean.valueOf(setTo));
                } else if (currentSetting.startsWith("termsonelist:")) {
                    setTo = caseSetting.substring("termsonelist:".length());
                    Window.tfTermsOne.setText(setTo);
                } else if (currentSetting.startsWith("termstwolist:")) {
                    setTo = caseSetting.substring("termstwolist:".length());
                    Window.tfTermsTwo.setText(setTo);
                } else if (currentSetting.startsWith("uuid:")) {
                    setTo = caseSetting.substring("uuid:".length());
                    Window.cbUUID.setSelected(Boolean.valueOf(setTo));
                } else if (currentSetting.startsWith("fakeuuid:")) {
                    setTo = caseSetting.substring("fakeuuid:".length());
                    Window.cbFakeUUID.setSelected(Boolean.valueOf(setTo));
                } else if (currentSetting.startsWith("zipfile:")) {
                    setTo = caseSetting.substring("zipfile:".length());
                    Window.cbZip.setSelected(Boolean.valueOf(setTo));
                } else if (currentSetting.startsWith("watermark:")) {
                    setTo = caseSetting.substring("watermark:".length());
                    Window.cbWatermark.setSelected(Boolean.valueOf((setTo)));
                } else if (currentSetting.startsWith("author:")) {
                    setTo = caseSetting.substring("author:".length());
                    Window.tfAuthor.setText(setTo);
                } else if (currentSetting.startsWith("buyer:")) {
                    setTo = caseSetting.substring("buyer:".length());
                    Window.tfBuyer.setText(setTo);
                } else if (currentSetting.startsWith("pathshaderone:")) {
                    setTo = caseSetting.substring("pathshaderone:".length());
                    Directory.tfShader.setText(setTo);
                } else if (currentSetting.startsWith("pathshadertwo:")) {
                    setTo = caseSetting.substring("pathshadertwo:".length());
                    Directory.tfShaderTwo.setText(setTo);
                } else if (currentSetting.startsWith("pathshaderthree:")) {
                    setTo = caseSetting.substring("pathshaderthree:".length());
                    Directory.tfShaderThree.setText(setTo);
                } else if (currentSetting.startsWith("pathcgone:")) {
                    setTo = caseSetting.substring("pathcgone:".length());
                    Directory.tfCGOne.setText(setTo);
                } else if (currentSetting.startsWith("pathcgtwo:")) {
                    setTo = caseSetting.substring("pathcgtwo:".length());
                    Directory.tfCGTwo.setText(setTo);
                } else if (currentSetting.startsWith("pathcgthree:")) {
                    setTo = caseSetting.substring("pathcgthree:".length());
                    Directory.tfCGThree.setText(setTo);
                } else if (currentSetting.startsWith("patheditor:")) {
                    setTo = caseSetting.substring("patheditor:".length());
                    Directory.tfEditor.setText(setTo);
                } else if (currentSetting.startsWith("pathresource:")) {
                    setTo = caseSetting.substring("pathresource:".length());
                    Directory.tfResource.setText(setTo);
                } else if (currentSetting.startsWith("pathoutput:")) {
                    setTo = caseSetting.substring("pathoutput:".length());
                    Directory.tfOutput.setText(setTo);
                } else if (currentSetting.startsWith("pathlog:")) {
                    setTo = caseSetting.substring("pathlog:".length());
                    Directory.tfLog.setText(setTo);
                } else if (currentSetting.startsWith("shadername:")) {
                    setTo = caseSetting.substring("shadername:".length());
                    Directory.tfName.setText(setTo);
                } else if (currentSetting.startsWith("main:")) {
                    setTo = caseSetting.substring("main:".length());
                    Directory.tfMain.setText(setTo);
                } else if (currentSetting.startsWith("avoidcomments:")) {
                    setTo = caseSetting.substring("avoidcomments:".length());
                    Window.cbCommentsAvoid.setSelected(Boolean.valueOf(setTo));
                } else {
                    Main.lukaLog(0, "There was an error reading the settings, at line " + i + ", contents: " + currentSetting);
                }
            }catch(Exception e){
                Main.lukaLog(0, "There was an error reading the settings, at line " + i + ", probably due to Windows..");
            }
        }
        Main.lukaLog(0, "File read and settings applied.");
    }

    public static void ApplySettings(
            boolean randomComment,
            String randMaxLength,
            String randFreq,
            boolean grabpass,
            String grabpassList,
            boolean replaceTerms,
            boolean randomizeTerms,
            String termsListOne,
            String termsListTwo,
            boolean uuid,
            boolean fakeUUID,
            boolean zipFile,
            boolean watermark,
            String author,
            String buyer,
            String pathShaderOne,
            String pathShaderTwo,
            String pathShaderThree,
            String pathCGOne,
            String pathCGTwo,
            String pathCGThree,
            String pathEditor,
            String pathResource,
            String pathoutput,
            String pathLog,
            String shaderName,
            String main,
            boolean avoidComments
    ){
        Main.lukaLog(0, "Applying new settings..");
        String newSettings =
                        "RandomComment:" + randomComment + Main.lineBreak +
                        "RandMaxLength:" + randMaxLength + Main.lineBreak +
                        "RandFreq:" + randFreq + Main.lineBreak +
                        "Grabpass:" + grabpass + Main.lineBreak +
                        "GrabpassList:" + grabpassList + Main.lineBreak +
                        "ReplaceTerms:" + replaceTerms + Main.lineBreak +
                        "RandomizeTerms:" + randomizeTerms + Main.lineBreak +
                        "TermsOneList:" + termsListOne + Main.lineBreak +
                        "TermsTwoList:" + termsListTwo + Main.lineBreak +
                        "UUID:" + uuid + Main.lineBreak +
                        "FakeUUID:" + fakeUUID + Main.lineBreak +
                        "ZipFile:" + zipFile + Main.lineBreak +
                        "Watermark:" + watermark + Main.lineBreak +
                        "Author:" + author + Main.lineBreak +
                        "Buyer:" + buyer + Main.lineBreak +
                        "PathShaderOne:" + pathShaderOne + Main.lineBreak +
                        "PathShaderTwo:" + pathShaderTwo + Main.lineBreak +
                        "PathShaderThree:" + pathShaderThree + Main.lineBreak +
                        "PathCGOne:" + pathCGOne + Main.lineBreak +
                        "PathCGTwo:" + pathCGTwo + Main.lineBreak +
                        "PathCGThree:" + pathCGThree + Main.lineBreak +
                        "PathEditor:" + pathEditor + Main.lineBreak +
                        "PathResource:" + pathResource + Main.lineBreak +
                        "PathOutput:" + pathoutput + Main.lineBreak +
                        "PathLog:" + pathLog + Main.lineBreak +
                        "ShaderName:" + shaderName + Main.lineBreak +
                        "Main:" + main + Main.lineBreak +
                        "AvoidComments:" + avoidComments + Main.lineBreak;
        Main.writeFile(getLibrary() + File.separator + "settings.txt", newSettings);
        Main.lukaLog(0, "New settings wrote.");
    }

    public static void testDirectory(){
        String newSettings = "i made it!";
        Main.writeFile(getLibrary() + File.separator + "settings.txt", newSettings);
    }

}
