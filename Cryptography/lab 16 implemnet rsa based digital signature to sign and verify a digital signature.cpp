#include <iostream>
#include <cmath>

using namespace std;

typedef unsigned long long ull;

// Function to compute gcd of a and b
ull gcd(ull a, ull b) {
    while (b != 0) {
        ull temp = b;
        b = a % b;
        a = temp;
    }
    return a;
}

// Function to compute modular exponentiation
ull modExp(ull base, ull exp, ull mod) {
    ull result = 1;
    while (exp > 0) {
        if (exp % 2 == 1) { // If exp is odd
            result = (result * base) % mod;
        }
        base = (base * base) % mod;
        exp /= 2;
    }
    return result;
}

// Function to find modular inverse of a under modulo m
ull modInverse(ull a, ull m) {
    ull m0 = m, t, q;
    ull x0 = 0, x1 = 1;

    if (m == 1) return 0;

    while (a > 1) {
        q = a / m;
        t = m;

        m = a % m;
        a = t;
        t = x0;

        x0 = x1 - q * x0;
        x1 = t;
    }

    if (x1 < 0) x1 += m0;

    return x1;
}

// Function to generate RSA keys
void generateRSAKeys(ull p, ull q, ull e, ull &n, ull &d) {
    n = p * q;
    ull phi = (p - 1) * (q - 1);

    // Compute private key exponent d
    d = modInverse(e, phi);
}

// Function to sign a message
ull signMessage(ull message, ull d, ull n) {
    return modExp(message, d, n);
}

// Function to verify a signature
bool verifySignature(ull signature, ull message, ull e, ull n) {
    return modExp(signature, e, n) == message;
}

int main() {
    ull p, q, e, message;

    // Input primes p and q
    cout << "Enter two prime numbers (p and q): ";
    cin >> p >> q;

    // Input public key exponent e
    cout << "Enter the public key exponent (e): ";
    cin >> e;

    ull n, d;
    generateRSAKeys(p, q, e, n, d);

    cout << "Public key (n, e): (" << n << ", " << e << ")" << endl;
    cout << "Private key (d): " << d << endl;

    // Input message
    cout << "Enter a message to sign: ";
    cin >> message;

    ull signature = signMessage(message, d, n);

    cout << "Signature: " << signature << endl;

    // Verify the signature
    if (verifySignature(signature, message, e, n)) {
        cout << "Signature verification succeeded." << endl;
    } else {
        cout << "Signature verification failed." << endl;
    }

    return 0;
}
