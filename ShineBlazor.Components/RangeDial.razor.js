export class RangeDial {

    constructor(wrapper, knob, rangeInput) {
        this.wrapper = wrapper;
        this.knob = knob;
        this.rangeInput = rangeInput;

        document.addEventListener("mousedown", this.startMouseEvents);
        this.updateValue(this.rangeInput.value);
    }

    startMouseEvents = (e) => {
        let dial = e.target.closest(".range-dial");
        if (dial == this.wrapper) {

            document.addEventListener("mousemove", this.rotateKnob);
            document.addEventListener("mouseup", this.stopRotate);
        };
    }

    rotateKnob = (e) => {
        let knobX = this.knob.getBoundingClientRect().left + this.knob.clientWidth / 2;
        let knobY = this.knob.getBoundingClientRect().top + this.knob.clientHeight / 2;

        let deltaX = e.clientX - knobX;
        let deltaY = e.clientY - knobY;

        let angleRad = Math.atan2(deltaY, deltaX);
        let angleDeg = (angleRad * 180) / Math.PI;

        let rotationAngle = (angleDeg - 135 + 360) % 360;

        if (rotationAngle <= 270) {
            this.wrapper.style.setProperty('--dial-pointer-angle', `${rotationAngle - 45}deg`);
            let newValue = Math.ceil((rotationAngle / 270)*100);

            this.wrapper.style.setProperty('--dial-progress', newValue);
            this.rangeInput.value = newValue;
        }
    }

    stopRotate = () => {
        this.rangeInput.dispatchEvent(new Event("change", { bubbles: true }));

        document.removeEventListener("mousemove", this.rotateKnob);
        document.removeEventListener("mouseup", this.stopRotate);
    }

    updateValue(value) {
        this.wrapper.style.setProperty('--dial-progress', value);
        let rotationAngle = (value / 100) * 270;
        this.wrapper.style.setProperty('--dial-pointer-angle', `${rotationAngle - 45}deg`);
    }

    dispose() {
        this.stopRotate();
        document.removeEventListener("mousedown", this.startMouseEvents);
    }
}

export function CreateRangeDial(wrapper, knob, rangeInput) {
    return new RangeDial(wrapper, knob, rangeInput);
}