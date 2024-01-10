import RPi.GPIO as GPIO
import time
import sys

En1Pin = 3
In1Pin = 5
In2Pin = 7

GPIO.setmode(GPIO.BOARD)
GPIO.setup(En1Pin, GPIO.OUT)
GPIO.setup(In1Pin, GPIO.OUT)
GPIO.setup(In2Pin, GPIO.OUT)

en1 = GPIO.PWM(En1Pin, 100)
en1.start(0)
en1.ChangeDutyCycle(0)

for direction in [True, False]:
    print('running ' + ('forward' if direction else 'backward'))

    # what is which direction depends on how the motor is wired
    GPIO.output(In1Pin, direction)
    GPIO.output(In2Pin, not direction)
    stepSize = 10

    for x in range(int(100 / stepSize)):
        speed = stepSize * (x + 1)
        print('speed: {}'.format(speed))
        sys.stdout.flush()
        en1.ChangeDutyCycle(speed)
        time.sleep(2)

print('done')

GPIO.output(In1Pin, False)
GPIO.output(In2Pin, False)

# stops anyway when en1 goes out of scope
en1.ChangeDutyCycle(0)
en1.stop()
GPIO.cleanup()