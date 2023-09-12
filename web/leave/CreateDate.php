<?php
//show errors
ini_set('display_errors', 1);
ini_set('display_startup_errors', 1);
error_reporting(E_ALL);
//creating needed files
$newDate = $_POST['latestDate'];
$newCount = $_POST['latestCount'];
$newMessage = $_POST['latestMessage'];
$userIdentification = $_POST['userIdentification'];
$newCountry = $_POST['latestCountry'];
$dateFile = fopen("LeaveDataDate.txt", "w") or die("[lukalog] Issue creating file! (date)");
fwrite($dateFile, "$newDate");
fclose($dateFile);
$countFile = fopen("LeaveDataCount.txt", "w") or die("[lukalog] Issue creating file! (count)");
fwrite($countFile, "$newCount");
fclose($countFile);
$countryFile = fopen("LeaveDataCountry.txt", "w") or die("[lukalog] Issue creating file! (count)");
fwrite($countryFile, "$newCountry");
fclose($countryFile);
$messageFile = fopen("LeaveDataMessage.txt", "w") or die("[lukalog] Issue creating file! (message)");
fwrite($messageFile, "$newMessage");
fclose($messageFile);
//logging
$logFile = fopen("LeaveLogger.txt", "a") or die("[lukalog] Issue creating file! (message)");
fwrite($logFile, $newCount);
fwrite($logFile, $newDate);
//fwrite($logFile, $userIdentification);
fwrite($logFile, $newCountry);
fwrite($logFile, $newMessage);
fclose($logFile);
?>
