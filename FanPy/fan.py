import RPi.GPIO as GPIO
import time
import requests

C_SCHOPPE_IP = "http://172.20.115.17:5010"

def get():
    global C_SCHOPPE_IP
    url = C_SCHOPPE_IP + "/V1/Sensor?amount=1"
    x = requests.get(url)
    print(x.text)
    temparatures = x.json()["data"]["sensorDatas"]
    print(temparatures[len(temparatures) - 1]["kelvin"])
    return int(temparatures[len(temparatures) - 1]["kelvin"])

GPIO.setmode(GPIO.BCM)
Motor1A= 23
Motor2A = 24
Motor1EN = 25

GPIO.setup(Motor1A, GPIO.OUT)
GPIO.setup(Motor2A, GPIO.OUT)
GPIO.setup(Motor1EN, GPIO.OUT)

def forward():
    GPIO.output(Motor1A, GPIO.HIGH)
    GPIO.output(Motor2A, GPIO.LOW)

def reverse():
    GPIO.output(Motor1A, GPIO.LOW)
    GPIO.output(Motor2A, GPIO.HIGH)

def ramp_up():
    pwm.start(80)
    for i in range(80, 110, 10):
        pwm.ChangeDutyCycle(i)
        print("{0}%".format(i))
        time.sleep(5)

def run():
    pwm = GPIO.PWM(Motor1EN, 1000)
    forward()
    while True:
        temp = get()
        if temp >= 293:
            ramp_up()
            time.sleep(1)
        if temp < 293:
            pwm.stop()
            time.sleep(1)

run()
GPIO.cleanup()
