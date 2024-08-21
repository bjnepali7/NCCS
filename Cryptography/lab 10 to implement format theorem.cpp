#include <bits/stdc++.h>
using namespace std;

// To compute x raised to power y under modulo m
int power(int x, unsigned int y, unsigned int m) {
    if (y == 0)
        return 1;
    int p = power(x, y / 2, m) % m;
    p = (p * p) % m;

    return (y % 2 == 0) ? p : (x * p) % m;
}

// Function to find modular inverse of a under modulo m
// Assumption: m is prime
void modInverse(int a, int m) {
    if (__gcd(a, m) != 1)
        cout << "Inverse doesn't exist" << endl;
    else {
        // If a and m are relatively prime, then
        // modulo inverse is a^(m-2) mod m
        cout << "Modular multiplicative inverse is "
             << power(a, m - 2, m) << endl;
    }
}

// Driver Program
int main() {
    int a, m;

    // Get integer 'a' from the user
    cout << "Enter an integer a: ";
    cin >> a;

    // Get prime modular divisor 'm' from the user
    cout << "Enter a prime number m (modulus): ";
    cin >> m;

    // Find and print the modular inverse
    modInverse(a, m);
    return 0;
}

