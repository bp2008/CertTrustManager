# CertTrustManager
A simple Windows program which can hold an embedded SSL/TLS certificate (.cer file) and provides a button to trust or untrust that certificate.

## Usage

### First, embed a certificate
1. Download from [the releases section](https://github.com/bp2008/CertTrustManager/releases).  
2. Run `CertTrustManager.exe`. Because we're dealing with certificate trust, administrator permission is required. 
![Screenshot](https://i.imgur.com/XMlGq3V.png)  
3. Right-click anywhere in the body of the panel, then click the button in the context menu to browse for a `.cer` file to embed.  
4. Use the Browse panel to open a `.cer` file.  In the current working directory, a new exe will be written, named after your `.cer` file.  This new exe is a copy of CertTrustManager with your `.cer` file embedded.  

    ![Screenshot](https://i.imgur.com/T7vPBfu.png)

### Distribute the trust manager with embedded certificate.

People can instruct their Windows systems to trust your certificate simply by running the exe you gave them, and clicking `Trust Certificate`.  When the certificate is trusted, the `Trust Certificate` button changes to `Untrust Certificate` so trust can be easily revoked.

### Command-line usage

CertTrustManager has basic support for command-line usage so you can use it from a script.

```
Usage: CertTrustManager.exe [trust|untrust|istrusted]
                trust - The embedded certificate will be trusted
                untrust - The embedded certificate will be untrusted
                istrusted - application will write "trusted" or "untrusted" to stdout
```
