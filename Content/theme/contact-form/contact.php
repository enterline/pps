<?php if (!isset($_SESSION)) session_start();

if(!$_POST) exit;

	if (!defined("PHP_EOL")) define("PHP_EOL", "\r\n");


///////////////////////////////////////////////////////////////////////////
// 1. Specify the Email Address where the form should be sent to:
///////////////////////////////////////////////////////////////////////////


	$address = "example@codecanyon.net";
	
	
	// Example single email address:
	// $address = "joe.doe@yourdomain.com";
	
	
	// Example multiple email addresses:
	// $address = "example1@codecanyon.net";
	// $address .= ",example2@codecanyon.net";
	// $address .= ",example3@codecanyon.net";




	// Twitter Direct Message notification control.
		// Keep $twitter_active set to 0 to disable Twitter Notification
		$twitter_active		= 0;

		// Get your consumer key and consumer secret from http://dev.twitter.com/apps/new
			// Notes:
				// Application Name: Jigowatt Contact Form
				// Description: Jigowatt Contact Form Direct Messaging Funcionality
				// Application Website: (your website address)
				// Application Type: Browser
				// Callback URL: (Blank)
				// Default Access type: Read and Write
		$twitter_user		= ""; // Your user name
		$consumer_key		= "";
		$consumer_secret	= "";

		// Access Token and Access Token Secret is under "My Access Token" (right menu).
		$token				= "";
		$secret				= "";
		
		



///////////////////////////////////////////////////////////////////////////
// 2. Retrieve form field values and store into variables:
///////////////////////////////////////////////////////////////////////////

	$name	  = $_POST['name'];
	$email	  = $_POST['email'];
	$phone	  = $_POST['phone'];
	$comments = $_POST['comments'];
	
	// End form value retrieval
	
	

	if (isset($_POST['verify'])) :
		$posted_verify   = $_POST['verify'];
   		$posted_verify   = md5($posted_verify);
   	else :
   		$posted_verify = '';
   	endif;

	// Important Variables
	$session_verify = $_SESSION['verify'];

	if (empty($session_verify)) $session_verify = $_COOKIE['verify'];

	$error = '';



///////////////////////////////////////////////////////////////////////////
// 3. Check for required fields and specify error messages for each field:
///////////////////////////////////////////////////////////////////////////
		
		if(trim($name) == '') {
			$error .= '<li>Your name is required.</li>';
		}

		if(trim($email) == '') {
			$error .= '<li>Your e-mail address is required.</li>';
		} elseif(!isEmail($email)) {
			$error .= '<li>You have entered an invalid e-mail address.</li>';
		}

		if(trim($phone) == '') {
			$error .= '<li>Your phone number is required.</li>';
		} elseif(!is_numeric($phone)) {
			$error .= '<li>Your phone number can only contain digits.</li>';
		}

		if(trim($comments) == '') {
			$error .= '<li>You must enter a message to send.</li>';
		}

		if($session_verify != $posted_verify) {
			$error .= '<li>The verification code you entered is incorrect.</li>';
		}

		if($error != '') {
			echo '<div class="notification error closeable"><p><strong>Attention! Please correct the errors below and try again.</strong></p>';
			echo '<ul class="error_messages">' . $error . '</ul>';
			echo '</div>';

		} else {

		if(get_magic_quotes_gpc()) { $comments = stripslashes($comments); }

		 
		 
		 
		 
		 
///////////////////////////////////////////////////////////////////////////
// 4. Format the email message sent to your inbox:
///////////////////////////////////////////////////////////////////////////

		 // Subject line of the email:
		 $e_subject = 'You\'ve been contacted by ' . $name . '.';


		 // Email message:
		 $msg  = "You have been contacted by $name. Their message is as follows:" . PHP_EOL . PHP_EOL;
		 $msg .= "$comments" . PHP_EOL . PHP_EOL;
		 $msg .= "You can contact $name via email, $email or via phone $phone." . PHP_EOL . PHP_EOL;
		 $msg .= "-------------------------------------------------------------------------------------------" . PHP_EOL;
		 $msg .= "This message was sent to you via your website Contact Form";
		 
		 

		if($twitter_active == 1) {

			$twitter_msg = $name . " - " . $comments . ". You can contact " . $name . " via email, " . $email ." or via phone " . $phone . ".";
			twittermessage($twitter_user, $twitter_msg, $consumer_key, $consumer_secret, $token, $secret);

		}

		$msg = wordwrap( $msg, 70 );

		$headers = "From: $email" . PHP_EOL;
		$headers .= "Reply-To: $email" . PHP_EOL;
		$headers .= "MIME-Version: 1.0" . PHP_EOL;
		$headers .= "Content-type: text/plain; charset=utf-8" . PHP_EOL;
		$headers .= "Content-Transfer-Encoding: quoted-printable" . PHP_EOL;

		if(mail($address, $e_subject, $msg, $headers)) {

		 echo "<fieldset>";
		 echo "<div class=\"notification success closeable\">";
		 echo "<p><strong>Email Sent Successfully.</strong><br />";
		 echo "Thank you $name, your message has been submitted to us.</p>";
		 echo "</div>";
		 echo "</fieldset>";

		 } else {

		 echo 'ERROR!'; // Dont Edit.

		 }

	}

function twittermessage($user, $message, $consumer_key, $consumer_secret, $token, $secret) { // Twitter Direct Message function, do not edit.

	require_once('twitter/EpiCurl.php');
	require_once('twitter/EpiOAuth.php');
	require_once('twitter/EpiTwitter.php');

	$Twitter = new EpiTwitter($consumer_key, $consumer_secret);
	$Twitter->setToken($token, $secret);

	$direct_message = $Twitter->post_direct_messagesNew( array('user' => $user, 'text' => $message) );
	$tweet_info = $direct_message->responseText;

}

function isEmail($email) { // Email address verification, do not edit.

return(preg_match("/^[-_.[:alnum:]]+@((([[:alnum:]]|[[:alnum:]][[:alnum:]-]*[[:alnum:]])\.)+(ad|ae|aero|af|ag|ai|al|am|an|ao|aq|ar|arpa|as|at|au|aw|az|ba|bb|bd|be|bf|bg|bh|bi|biz|bj|bm|bn|bo|br|bs|bt|bv|bw|by|bz|ca|cc|cd|cf|cg|ch|ci|ck|cl|cm|cn|co|com|coop|cr|cs|cu|cv|cx|cy|cz|de|dj|dk|dm|do|dz|ec|edu|ee|eg|eh|er|es|et|eu|fi|fj|fk|fm|fo|fr|ga|gb|gd|ge|gf|gh|gi|gl|gm|gn|gov|gp|gq|gr|gs|gt|gu|gw|gy|hk|hm|hn|hr|ht|hu|id|ie|il|in|info|int|io|iq|ir|is|it|jm|jo|jp|ke|kg|kh|ki|km|kn|kp|kr|kw|ky|kz|la|lb|lc|li|lk|lr|ls|lt|lu|lv|ly|ma|mc|md|me|mg|mh|mil|mk|ml|mm|mn|mo|mp|mq|mr|ms|mt|mu|museum|mv|mw|mx|my|mz|na|name|nc|ne|net|nf|ng|ni|nl|no|np|nr|nt|nu|nz|om|org|pa|pe|pf|pg|ph|pk|pl|pm|pn|pr|pro|ps|pt|pw|py|qa|re|ro|ru|rw|sa|sb|sc|sd|se|sg|sh|si|sj|sk|sl|sm|sn|so|sr|st|su|sv|sy|sz|tc|td|tf|tg|th|tj|tk|tm|tn|to|tp|tr|tt|tv|tw|tz|ua|ug|uk|um|us|uy|uz|va|vc|ve|vg|vi|vn|vu|wf|ws|ye|yt|yu|za|zm|zw)$|(([0-9][0-9]?|[0-1][0-9][0-9]|[2][0-4][0-9]|[2][5][0-5])\.){3}([0-9][0-9]?|[0-1][0-9][0-9]|[2][0-4][0-9]|[2][5][0-5]))$/i",$email));

}
?>