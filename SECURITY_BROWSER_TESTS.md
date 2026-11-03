# Browser-driver security maintenance

Browser drivers are resolved by Selenium Manager from Selenium.WebDriver 4.52.0.
Do not commit executable browser drivers or pin incompatible ChromeDriver/GeckoDriver/EdgeDriver packages.
Run the CI suite on a supported Windows runner while migrating this legacy .NET 5 test stack.

The ReportPortal credential was previously committed and must be revoked/rotated.
External ReportPortal publishing is disabled by default in checked-in configuration;
enable it only using protected settings outside Git. Historical Git commits still require cleanup.
