# Stepometer.Service
 
Config for local IIS

<site name="Service" id="2">
                <application path="/" applicationPool="Clr4IntegratedAppPool">
                    <virtualDirectory path="/" physicalPath="{path to derectory}" />
                </application>
                <bindings>
                    <binding protocol="https" bindingInformation="*:44301:localhost" />
                    <binding protocol="http" bindingInformation="*:44301:localhost" />
                    <binding protocol="https" bindingInformation="*:44301:127.0.0.1" />
                    <binding protocol="http" bindingInformation="*:56897:127.0.0.1" />
                </bindings>
            </site>