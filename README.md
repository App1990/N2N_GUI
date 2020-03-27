shell脚本，自动搭建n2n内网穿透服务器

# CentOS 7使用方法：
安装wget组件和解压缩工具 
``` Linux Commands
yum -y install wget 
```

获取脚本文件 
``` Linux Commands
wget --no-check-certificate -O n2n.sh https://raw.githubusercontent.com/App1990/n2n_gui/master/n2n.sh 
```

将文件标记为可执行脚本 
``` Linux Commands
chmod +x n2n.sh 
```

执行脚本 
``` Linux Commands
./n2n.sh 
```
