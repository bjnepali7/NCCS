#include <iostream>
#include <cstdlib>
#include <ctime>

using namespace std; // Allows use of standard library names without 'std::'

// Function to compute (base^exp) % mod using modular exponentiation
int mod_exp(int base, int exp, int mod) {
    int result = 1;
    while (exp > 0) {
        if (exp % 2 == 1) {
            result = (result * base) % mod;
        }
        base = (base * base) % mod;
        exp /= 2;
    }
    return result;
}

// ElGamal Key Generation
void generate_keys(int& p, int& g, int& x, int& y) {
    // Example values for simplicity; use large primes in practice
    p = 23; // Prime modulus
    g = 5;  // Generator

    // Generate private key x
    x = rand() % (p - 1) + 1;

    // Compute public key y = g^x % p
    y = mod_exp(g, x, p);
}

// Encryption
void encrypt(int p, int g, int y, int m, int& c1, int& c2) {
    int k = rand() % (p - 1) + 1; // Random integer k
    c1 = mod_exp(g, k, p); // Compute c1 = g^k % p
    c2 = (m * mod_exp(y, k, p)) % p; // Compute c2 = m * y^k % p
}

// Decryption
int decrypt(int p, int x, int c1, int c2) {
    int s = mod_exp(c1, x, p); // Compute s = c1^x % p
    // Compute the modular inverse of s mod p (using extended Euclidean algorithm)
    int inv_s = 1;
    for (int i = 1; i < p; ++i) {
        if ((s * i) % p == 1) {
            inv_s = i;
            break;
        }
    }
    return (c2 * inv_s) % p; // Compute m = c2 * s^-1 % p
}

int main() {
    srand(static_cast<unsigned int>(time(0))); // Seed random number generator

    int p, g, x, y;
    generate_keys(p, g, x, y);

    int m = 10; // Example message
    int c1, c2;

    encrypt(p, g, y, m, c1, c2);

    cout << "Encrypted message: (" << c1 << ", " << c2 << ")\n";

    int decrypted_message = decrypt(p, x, c1, c2);
    cout << "Decrypted message: " << decrypted_message << "\n";

    return 0;
}

