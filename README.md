# Email_OTP_Gen

Email Trigger Solution Tested Results.

1.	User Give Valid Email and trigger email successfully. (Positive)
Payload: 
{
  "email": "test@gov.dso.org.sg"
}

Response

![image](https://github.com/user-attachments/assets/bb74cbae-b3cb-4a25-b7d0-c559aebc8f00)



2.	Verify OTP  (Positive)

Payload
{
  "email": "test@gov.dso.org.sg",
  "otp": "567231"
}

![image](https://github.com/user-attachments/assets/f9c99c2b-542d-41d3-9b1b-6195b6565e06)


3.	Validate Email (Negative)
Payload 
{
  "email": "test@gov.dso.org.sg0000"
}

![image](https://github.com/user-attachments/assets/b61a4a2d-9edd-4545-97ee-dc56fee5b9b6)



4.	Entering Wrong OTP, count will be added each failed OTP verification (Negative)
Payload we highlighted on the below screenshot

![image](https://github.com/user-attachments/assets/36289e56-f53a-43f0-bf31-3465c44d852e)


5.	OTP Expires User Enter the OTP After 1 Min (Negative)
Payload we highlighted on the below screenshot
![image](https://github.com/user-attachments/assets/b00e8fc5-53c0-4aef-8f44-9bde80dc75d4)





