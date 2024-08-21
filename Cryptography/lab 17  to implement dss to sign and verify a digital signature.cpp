#include <iostream>
#include <random>
#include <cmath>
#include <string>
#include <vector>

using namespace std;

// Example prime and base (normally should be large and randomly generated)
const long long P = 0xFFFFFFC5; // A large prime
const long long Q = 0xFFFFFFF7; // A large prime factor of P-1
const long long G = 2; // Base

// Example private key
const long long X = 123456789; // Private key (should be securely generated)

// Function to compute modular exponentiation (base^exp % mod)
long long modExp(long long base, long long exp, long long mod) {
    long long result = 1;
    base = base % mod;
    while (exp > 0) {
        if (exp % 2 == 1) { // If exp is odd
            result = (result * base) % mod;
        }
        exp = exp >> 1; // Divide exp by 2
        base = (base * base) % mod;
    }
    return result;
}

// Generate the signature
pair<long long, long long> signMessage(const string &message, long long privateKey) {
    random_device rd;
    mt19937 gen(rd());
    uniform_int_distribution<long long> dis(1, Q - 1);
    
    // Hash the message (using a simple hash function for demonstration)
    long long H = 0;
    for (char c : message) {
        H = (H * 31 + c) % Q;
    }

    // Generate random k
    long long k = dis(gen);

    // Compute r and s
    long long r = modExp(G, k, P) % Q;
    long long k_inv = modExp(k, Q - 2, Q); // Modular inverse of k
    long long s = (k_inv * (H + privateKey * r)) % Q;

    return {r, s};
}

// Verify the signature
bool verifySignature(const string &message, long long r, long long s, long long publicKey) {
    // Hash the message
    long long H = 0;
    for (char c : message) {
        H = (H * 31 + c) % Q;
    }

    // Compute v1 and v2
    long long w = modExp(s, Q - 2, Q); // Modular inverse of s
    long long u1 = (H * w) % Q;
    long long u2 = (r * w) % Q;

    long long v1 = modExp(G, u1, P);
    long long v2 = modExp(publicKey, u2, P);
    v2 = (v1 * v2) % P;
    v1 = v2 % Q;

    return v1 == r;
}

int main() {
    // Generate public key Y
    long long Y = modExp(G, X, P);

    string message = "This is a test message.";

    // Sign the message
    auto [r, s] = signMessage(message, X);
    cout << "Signature (r, s): " << r << ", " << s << endl;

    // Verify the signature
    bool isValid = verifySignature(message, r, s, Y);
    cout << (isValid ? "Signature verification succeeded.\n" : "Signature verification failed.\n");

    return 0;
}

