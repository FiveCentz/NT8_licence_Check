<?php
// used to determine machine ID who has paid
set_time_limit(0);
ignore_user_abort(true);
ini_set('display_errors', 1);
ini_set('log_errors', 1);
error_reporting(E_ALL);
date_default_timezone_set('America/Chicago' ) ;
$zlog_file = "/var/www/optimumfinance/zmid" . "_log.txt"        ;
$machine_id =  htmlspecialchars($_GET["machid"]);

//echo 'Machine_ID :' . $machine_id  . "<br />";;

//error_log(__FILE__ . " : " . __LINE__    . " : " . print_r($_REQUEST,TRUE) . "\n",3,$zlog_file );
// PDO
$PDO_Dbtype = "mysql";
$PDO_Host  = "localhost";
$PDO_User   = "fivecent";
$PDO_Password    = "Oaks3118@";
$PDO_DB      = "optifin";
$PDO_CharSet = "utf8";

$PDO_DSN = "mysql:host=$PDO_Host;dbname=$PDO_DB;port=3306";
$PDO_opt = [
    PDO::ATTR_ERRMODE            => PDO::ERRMODE_EXCEPTION,
    PDO::ATTR_DEFAULT_FETCH_MODE => PDO::FETCH_ASSOC,
    PDO::ATTR_EMULATE_PREPARES   => false,
        PDO::MYSQL_ATTR_INIT_COMMAND => "SET NAMES utf8;"
];

try {
        $PDO_handle = new PDO($PDO_DSN, $PDO_User, $PDO_Password);

} catch (PDOException $e) {
    print "Error!: " . $e->getMessage() . "<br/>";
    die();
}

$PDO_handle->setAttribute(PDO::ATTR_EMULATE_PREPARES,false);
$PDO_handle->setAttribute( PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION );
// PDO
//
$sql = "select LIFE_LONG , expires_on updt  FROM fc_nt_indicators where MACHINE_ID = '" . $machine_id . "'";
//echo $sql . "<br />";

$stmt = $PDO_handle->query($sql);
if ( $stmt->rowCount() > 0)
{
        while ($row = $stmt->fetch()) {
            echo $row['LIFE_LONG']. "|" . $row['updt'] ;
        }
}
else
{
        echo "9|2024-05-31 08:09:18";
        error_log(__FILE__ . " : " . __LINE__    . " : " . print_r($_REQUEST,TRUE) . "\n",3,$zlog_file );
}
?>
