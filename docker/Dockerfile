FROM maven:3.8.5-openjdk-17

# Install dependencies and SonarScanner CLI
RUN apt-get update && apt-get install -y wget unzip \
    && wget -O /tmp/sonar-scanner-cli.zip https://binaries.sonarsource.com/Distribution/sonar-scanner-cli/sonar-scanner-cli-4.6.2.2472-linux.zip \
    && unzip /tmp/sonar-scanner-cli.zip -d /opt \
    && mv /opt/sonar-scanner-4.6.2.2472-linux /opt/sonar-scanner \
    && ln -s /opt/sonar-scanner/bin/sonar-scanner /usr/bin/sonar-scanner

ENV SONAR_SCANNER_HOME=/opt/sonar-scanner
ENV PATH=${SONAR_SCANNER_HOME}/bin:${PATH}

# Set JAVA_HOME to use Java 17
ENV JAVA_HOME=/usr/local/openjdk-17
ENV PATH=$JAVA_HOME/bin:$PATH
