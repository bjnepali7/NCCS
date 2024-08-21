#include <iostream>
#include <string>

using namespace std;

string encryptDecrypt(string text, string key) {
    string result = "";
    for (size_t i = 0; i < text.size(); ++i)
        result += text[i] ^ key[i % key.size()];  // Key is repeated if shorter than the text
    return result;
}

int main() {
    string plaintext, key;

    // Get plaintext from user
    cout << "Enter the plaintext: ";
    getline(cin, plaintext);

    // Get key from user
    cout << "Enter the key: ";
    getline(cin, key);

    // Encrypt the plaintext using the key
    string ciphertext = encryptDecrypt(plaintext, key);
    cout << "Encrypted text: " << ciphertext << endl;

    // Decrypt the ciphertext using the key
    string decryptedText = encryptDecrypt(ciphertext, key);
    cout << "Decrypted text: " << decryptedText << endl;

    return 0;
}

