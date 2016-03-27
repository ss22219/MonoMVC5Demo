cd $(dirname $0) #get script dir
basepath=$(pwd)  #get fullpath
service_name=fastcgi
service_port=9000

read -p "service name(${service_name}):" input

if [ -n "$input" ]; then
	service_name=$input
fi

read -p "service port(${service_port}):" input
if [ -n "$input" ]; then
	service_port=$input
fi

echo -e "[Unit]\n\
Description="${service_name}" mono fastcig\n\
After=network.target remote-fs.target nss-lookup.target\n\
\n\
[Service]\n\
Type=simple]
ExecStart="$(which fastcgi-mono-server4)" /applications=/:"${basepath}"/ /socket=tcp:127.0.0.1:"${service_port}" >/var/log/fastcgi-mono-"${service_name}" 2>&1 &\n\
ExecStop=/bin/kill -s QUIT $MAINPID\n\
\n\
[Install]\n\
WantedBy=multi-user.target\n\
" > /etc/systemd/system/"${service_name}".service
echo "writed to /etc/systemd/system/"${service_name}".service"
echo "ok! use 'systemctl start ${service_name}' start fastcgi service"

