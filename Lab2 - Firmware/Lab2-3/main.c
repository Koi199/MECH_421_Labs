#include "MSP430.h"

void main (void)
{
    // Hold the watchdog timer
    WDTCTL = WDTPW | WDTHOLD; 

    // Set pins 4.0 and 4.1 as input
    P4DIR &= ~(BIT0 | BIT1);  // Clear bits 0 and 1 → inputs
    P4SEL0 &= ~(BIT0 | BIT1); // Set bit 0 and 1 to 0
    P4SEL1 &= ~(BIT0 | BIT1); // Set bit 0 and 1 to 0

    P4OUT |= (BIT0 | BIT1); // Set resistor to pull up
    P4REN |= (BIT0 | BIT1); // Enable Resistor

    __enable_interrupt(); // Enable global interrupts
    P4IE |= (BIT0 | BIT1); // Enable port interrupt

    // Set pin 3.6 and pin 3.7 as outputs
    P3DIR |= BIT6 | BIT7;
    P3SEL0 &= ~(BIT6 | BIT7);
    P3SEL1 &= ~(BIT6 | BIT7);

    while(1){
        _NOP();

    }

}

// Setup ISR 
#pragma vector=PORT4_VECTOR
__interrupt void Port4(void){

    // Check if interrupt flag for BIT0 is high
    if (P4IFG & BIT0){
        P3OUT ^= (BIT6); // Toggle LED
        P4IFG &= ~BIT0; // Clear Interrupt flag
    }

    // Check if interrupt flag for BIT1 is high
    if (P4IFG & BIT1){
        P3OUT ^= (BIT7);
        P4IFG &= ~BIT1;
    }
}
