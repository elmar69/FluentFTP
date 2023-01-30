﻿using FluentFTP.Streams;

namespace FluentFTP.GnuTLS {

	public class FtpGnuConfig : IFtpStreamConfig {

		/// <summary>
		/// GnuTLS will add its own log messages to the FluentFTP log.
		/// Select the maximum verbosity of the GnuTLS messages, which are 
		/// all added to the FluentFTP log with serverity "verbose".
		/// The allowed values are 0-99.
		/// </summary>
		public int LogLevel { get; set; } = 2;

		/// <summary>
		/// In case of a catastrophic failure, how many messages at maximum
		/// verbosity should be output prior to termination.
		/// </summary>
		public int LogBuffSize { get; set; } = 150;

		/// <summary>
		/// You can set the priority string to be used for connections.
		/// You are STRONGLY advised to read the section on "priority strings" in
		/// the GnuTLS documentation (currently chapter 6.10 for GnuTLS 3.7.7)
		/// Either: Leave it empty. The GnuTLS defaults will be used.
		/// Or: Set it to a string that starts with "+" or "-". Then
		/// the following GnuTLS default ciphers will be modified by
		/// your entry.
		/// To disable TLS 1.3, use "-VERS-TLS1.3" or add ":-VERS-TLS1.3"
		/// Or: Set it to a string that **does not** starts with "+" or "-".
		/// Then the string will be used verbatim.
		/// Example: "SECURE256:+SECURE128:-ARCFOUR-128:-3DES-CBC:-MD5:+SIGN-ALL:-SIGN-RSA-MD5:+CTYPE-X509:-VERS-SSL3.0"
		/// To disable TLS 1.3, add ":-VERS-TLS1.3"
		/// Further examples:
		/// "NORMAL:-VERS-ALL:+VERS-TLS1.3"
		/// "NORMAL:-VERS-ALL:+VERS-TLS1.3:%NO_TICKETS"
		/// "NORMAL:-VERS-ALL:+VERS-TLS1.3:%NO_TICKETS_TLS12"
		/// "NORMAL:-VERS-ALL:+VERS-TLS1.3:%NO_SESSION_HASH"
		/// Note:
		/// %NO_TICKETS_TLS12 is enabled by default and cannot be disabled using the
		/// priority strings.
		/// </summary>
		public string Priority { get; set; } = string.Empty; // "-VERS-TLS1.3";

		/// <summary>
		/// Set the GnuTLS handshake timeout. Set to zero to disable.
		/// </summary>
		public int HandshakeTimeout { get; set; } = 5000;

	}
}