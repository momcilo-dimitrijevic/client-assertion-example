#!/bin/bash

openssl req -newkey rsa:4096 \
            -x509 \
            -sha256 \
            -days 3650 \
            -nodes \
            -out example.crt \
            -keyout example.key \
            -subj "/C=NO/ST=Oslo/L=Oslo/O=Security/OU=Test/CN=www.test.com"