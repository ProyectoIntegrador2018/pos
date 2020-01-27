from pagofon import encrypt
from depagofon import decrypt
import pytest


@pytest.fixture()
def message():
    return '{"ActivationCode":"1169325819","SystemModuleID":"","ProductServiceType":"0","RequestUniqueID":"11","MethodName":"GetProductDetails","RequestIP":"127.0.0.1"}'


def test_symmetry(message):
    encrypted = encrypt(message)
    decrypted = decrypt(encrypted)

    assert decrypted == message
