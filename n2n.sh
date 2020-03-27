#!/bin/bash

# install n2n on centos7 and use dhcp

yum install -y subversion openssl-devel cmake net-tools git gcc gcc-c++ dhcp zip unzip 

wget --no-check-certificate -O n2n.zip https://codeload.github.com/meyerd/n2n/zip/master

unzip n2n.zip

cd n2n-master/n2n_v2

mkdir build

cd build

cmake ..

make && make install

<<!
cat << EOF | tee /etc/dhcp/dhcpd.conf
ddns-update-style interim;
 
ignore client-updates;
 
default-lease-time 604800;
 
max-lease-time 1209600;
 
 
 
subnet 10.0.0.0 netmask 255.255.255.0 {
 
	option subnet-mask 255.255.255.0;
 
	range dynamic-bootp 10.0.0.1 10.0.0.255;
 
}
EOF
!

echo "ddns-update-style interim;
 
ignore client-updates;
 
default-lease-time 604800;
 
max-lease-time 1209600;
 
 
 
subnet 10.0.0.0 netmask 255.255.255.0 {
 
	option subnet-mask 255.255.255.0;
 
	range dynamic-bootp 10.0.0.1 10.0.0.255;
 
}" >/etc/dhcp/dhcpd.conf

echo "DHCPDARGS='edge0'" >>/etc/sysconfig/dhcpd



supernode -l 10001

edge -d edge0 -r -a 10.0.0.0 -c WeGame -k p@ssw0rd -l 0.0.0.0:10001

systemctl start dhcpd.service
