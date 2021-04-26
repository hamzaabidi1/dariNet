const voice = document.querySelector(".voice");
const voice2text = document.querySelector(".voice2text");

const SpeechRecognition = window.SpeechRecognition || window.webkitSpeechRecognition;
const recorder = new SpeechRecognition();

function addHumanText(text) {
    const chatContainer = document.createElement("div");
    chatContainer.classList.add("chat-container");
    const chatBox = document.createElement("p");
    chatBox.classList.add("voice2text");
    const chatText = document.createTextNode(text);
    chatBox.appendChild(chatText);
    chatContainer.appendChild(chatBox);
    return chatContainer;
}

function addBotText(text) {
    const chatContainer1 = document.createElement("div");
    chatContainer1.classList.add("chat-container");
    chatContainer1.classList.add("darker");
    const chatBox1 = document.createElement("p");
    chatBox1.classList.add("voice2text");
    const chatText1 = document.createTextNode(text);
    chatBox1.appendChild(chatText1);
    chatContainer1.appendChild(chatBox1);
    return chatContainer1;
}

function botVoice(message) {
    const speech = new SpeechSynthesisUtterance();
    speech.text = "Sorry, I do not have any idea about this just you should contact administration";

    if (message.includes('how are you')) {
        speech.text = "I am fine, thanks. How are you?";
    }

    if (message.includes('Hello')) {
        speech.text = "hello , you are welcome";
    }

    if (message.includes('fine')) {
        speech.text = "Nice to hear that. How can I assist you today?";
    }

    if (message.includes('courses')) {
        speech.text = "french,engilsh ... ";
    }

    if (message.includes('activity')) {
        speech.text = "drawing,music ... ";
    }

    if (message.includes('starting time')) {
        speech.text = "at 7";
    }
    if (message.includes('ending time')) {
        speech.text = "at 19";
    }

    if (message.includes('staff qualifications')) {
        speech.text = "our teachers are qualified to do any activity for a child they had a wide experience";
    }

    if (message.includes('what do the kids eat')) {
        speech.text = "we have a rich food for the child";
    }

    if (message.includes('sick')) {
        speech.text = "we have a doctor in our junior home";
    }

    if (message.includes('problems')) {
        speech.text = "if your child will have any problem just we contact you in a few ";
    }

    if (message.includes('transport')) {
        speech.text = "we have comfort buses for transport of child";
    }

    speech.volume = 1;
    speech.rate = 1;
    speech.pitch = 1;
    window.speechSynthesis.speak(speech);
    var element = document.getElementById("container");
    element.appendChild(addBotText(speech.text));
}

recorder.onstart = () => {
    console.log('Voice activated');
};

recorder.onresult = (event) => {
    const resultIndex = event.resultIndex;
    const transcript = event.results[resultIndex][0].transcript;
    var element = document.getElementById("container");
    element.appendChild(addHumanText(transcript));
    botVoice(transcript);
};

voice.addEventListener('click', () => {
    recorder.start();
});
