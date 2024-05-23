import glob
import time
import signal
import sys
import requests

path = "/sys/bus/w1/devices/"
host=""
sensor_path = glob.glob(path + "28*")[0]
sensor_data_path = sensor_path + "/w1_slave"
C_SCHOPPE_IP = "http://172.20.115.17:5010"

def post(kelvin):
    global C_SCHOPPE_IP
    url  =  C_SCHOPPE_IP + "/v1/Sensor"
    myobj = {
    "token": "044d1f4d-9136-460f-a786-5dd93a2a0859",
    "kelvin": kelvin
    }
    x = requests.post(url, json = myobj)
    print(x.text)

def read_temperature():
  file = open(sensor_data_path, "r")
  rows = file.readlines()
  file.close()
  return rows

def signal_handler(sig, frame):
    print('SIGINT caught. Shutting down...')
    sys.exit(0)

def get_temperature_in_degree():
  rows = read_temperature()
  while rows[0].strip()[-3:] != 'YES':
    time.sleep(0.2)
    rows = read_temperature()
  equals_pos = rows[1].find('t=')
  if equals_pos != -1:
      temp_string = rows[1][equals_pos+2:]
      temp_c = float(temp_string) / 1000.0
      return temp_c

signal.signal(signal.SIGINT, signal_handler)

while True:
  value = float(get_temperature_in_degree())
  print(value)
  time.sleep(5)
  post((value + 273.15))
